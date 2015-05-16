using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLToArduino
{
    class Rest : MusicalElement
    {
        public Rest(int length)
        {
            noteLength = length;
        }
        public override string ToString()
        {
            string retVal = "(Rest Note)";
            retVal += " Note Length: " + noteLength.ToString();
            if (msLength > 0)
                retVal += " MiliSecond Length: " + msLength.ToString();
            retVal += "\n";
            return retVal;
        }
    }
}
