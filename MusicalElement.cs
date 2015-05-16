using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLToArduino
{
    abstract class MusicalElement
    {
        protected int noteLength;
        protected uint msLength;
        protected bool isDotted;

        public uint CalculateNoteDuration(int tempo)
        {
            double normalizedMS = ((double)1 / noteLength) * 4;
            normalizedMS = (normalizedMS * ((double)60/tempo));
            normalizedMS *= 1000;
            if (isDotted)
                normalizedMS *= 1.5;
            msLength = (uint)normalizedMS;
            return (uint)normalizedMS;
        }
        public void SetIsDotted(bool dot) { isDotted = dot; }
    }

}
