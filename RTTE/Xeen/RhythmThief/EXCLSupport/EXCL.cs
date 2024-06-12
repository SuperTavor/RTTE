using System.Text;
namespace RTTE.Xeen.RhythmThief.EXCLSupport
{
    public class EXCL
    {
        public char[] Magic = new char[0x4];
        public int Unk0;
        public byte[] TrashPadding = new byte[0xC];
        public EXCLTextColor TextColor;
        public int EntryCount;
        List<int> EntryOffsets = new();
        //This field is used to find length changes between strings and adjust pointers.
        private List<int> _unmodifiedTextLens = new();
        public List<EXCLEntry> Entries = new();

        public byte[] Save()
        {
            using var mem = new MemoryStream();
            using var writer = new BinaryWriter(mem);
            writer.Write(Magic);
            writer.Write(Unk0);
            writer.Write(TrashPadding);
            writer.Write((Int32)TextColor);
            writer.Write(EntryCount);
            int nextEntryModifier = 0;
            for (int i = 0; i < EntryCount; i++)
            {
                writer.Write(EntryOffsets[i] + nextEntryModifier);
                int lengthDifference = (Entries[i].Content.Length - _unmodifiedTextLens[i]) * 2;
                nextEntryModifier += lengthDifference;
            }
            foreach (var entry in Entries)
            {
                writer.Write(entry.TrashPadding);
                writer.Write(entry.EntryMetadata);
                if(!string.IsNullOrEmpty(entry.Content))
                {
                    writer.Write(new EXCLStr(entry.Content).GetBytes());
                }
                else
                {
                    //Empty entries need 2 empty bytes to represent them, and we also prefix it with a 0x0 like all EXCL strings.
                    writer.Write([0x0,0x0, 0x0,0x0,0x0]);
                }
            }
            return mem.ToArray();
        }
        public void Load(byte[] file)
        {
            using var mem = new MemoryStream(file);
            using var reader = new BinaryReader(mem);
            Magic = reader.ReadChars(4);
            if (new string(Magic) != "EXCL")
            {
                throw new FormatException("File is not a valid Rhythm Thief text file");
            }
            Unk0 = reader.ReadInt32();
            TrashPadding = reader.ReadBytes(TrashPadding.Length);
            var textColor = (EXCLTextColor)reader.ReadInt32();
            if (Enum.IsDefined(typeof(EXCLTextColor), textColor))
            {
                TextColor = textColor;
            }
            else
            {
                MessageBox.Show("Invalid text color in file. Automatically set to white.","RTTE",MessageBoxButtons.OK);
                TextColor = EXCLTextColor.White;
            }
            EntryCount = reader.ReadInt32();
            for (int i = 0; i < EntryCount; i++)
            {
                EntryOffsets.Add(reader.ReadInt32());

            }

            for (int i = 0; i < EntryCount; i++)
            {
                //Read entry
                EXCLEntry entry = new EXCLEntry();
                entry.TrashPadding = reader.ReadBytes(entry.TrashPadding.Length);
                entry.EntryMetadata = reader.ReadBytes(entry.EntryMetadata.Length);
                //Get string
                StringBuilder resultString = new();
                while (true)
                {
                    var b = reader.ReadByte();
                    if (b == 0x0)
                    {
                        var peekByte = reader.ReadByte();
                        //Check if there are 2 0x0 in a row, which means nullterm in UTF-16
                        if (peekByte == 0x0)
                        {
                            int toSeek = 1;
                            if (string.IsNullOrEmpty(resultString.ToString())) toSeek = 3;
                            //For the remaining nullterm byte
                            mem.Seek(toSeek, SeekOrigin.Current);
                            break;
                        }
                        else
                        {
                            resultString.Append((char)peekByte);
                        }
                    }
                    else
                    {
                        resultString.Append((char)b);
                    }
                }
                entry.Content = resultString.ToString();
                _unmodifiedTextLens.Add(resultString.Length);
                Entries.Add(entry);
            }

        }
    }
}
