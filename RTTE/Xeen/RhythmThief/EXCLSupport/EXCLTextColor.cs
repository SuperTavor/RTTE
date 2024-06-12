using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTTE.Xeen.RhythmThief.EXCLSupport
{
    public enum EXCLTextColor : Int32
    {
        White = 0,
        Black = 1,
        Red = 2,
        LightBlue = 3,
        Orange = 4,
        //5 is a duplicate of 4.
        Pink = 6,
        Gray = 7,
        //8 is also gray and 9 is pink again. Any number after that makes the text go invisible
    }
}
