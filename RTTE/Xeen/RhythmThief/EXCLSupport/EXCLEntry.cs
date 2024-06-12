using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTTE.Xeen.RhythmThief.EXCLSupport
{
    public class EXCLEntry
    {
        public byte[] TrashPadding = new byte[0x28];
        public byte[] EntryMetadata = new byte[0x4F];
        public string Content = string.Empty;
    }
}
