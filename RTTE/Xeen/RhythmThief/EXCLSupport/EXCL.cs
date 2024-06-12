using System.Linq;
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
                writer.Write(entry.Unk0);
                writer.Write(entry.Unk1);
                if(!string.IsNullOrEmpty(entry.Content))
                {
                    writer.Write(Encoding.Unicode.GetBytes(entry.Content));
                   
                }
                else
                {
                    //Empty entries need 2 empty bytes to represent them, and we also prefix it with a 0x0 like all EXCL strings.
                    writer.Write([0x0,0x0]);
                }
                //Null terminator
                writer.Write([0x0, 0x0]);
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
            if(Unk0 == 6 || Unk0 == 4)
            {
                throw new FormatException($"EXCL{Unk0} detected. Unsupported EXCL variation.\n\nDo not panic, though! EXCL{Unk0} files are not used ingame, and barely contain any text.");
            }
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
                entry.Unk0 = reader.ReadBytes(entry.Unk0.Length);
                entry.Unk1 = reader.ReadBytes(entry.Unk1.Length);
                //Read string
                StringBuilder resultSB = new();
                while(true)
                {
                    var chr = reader.ReadBytes(2); 
                    byte[] nullTermChar = [0x00, 0x00];
                    if (chr.SequenceEqual(nullTermChar))
                    {
                        if(resultSB.Length == 0) mem.Seek(2,SeekOrigin.Current);
                        break;
                    }
                    else
                    {
                        resultSB.Append(Encoding.Unicode.GetChars(chr));
                    }
                }
                _unmodifiedTextLens.Add(resultSB.Length);
                entry.Content = resultSB.ToString();
                Entries.Add(entry);
            }

        }
    }
}
