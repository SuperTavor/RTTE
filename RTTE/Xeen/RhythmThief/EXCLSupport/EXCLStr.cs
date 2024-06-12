namespace RTTE.Xeen.RhythmThief.EXCLSupport
{
    public class EXCLStr
    {
        private List<byte> _stringData;

        public EXCLStr(string str)
        {
            _stringData = new List<byte>();
            foreach (char c in str)
            {
                _stringData.Add(0x0);
                _stringData.Add((byte)c);
            }
            //nullterm and final 0x0 
            _stringData.AddRange([0x0,0x0, 0x0]);
        }
        public byte[] GetBytes()
        {
           return _stringData.ToArray();
        }

  
    }
}
