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

        public uint CalculateNoteDuration(int tempo)
        {
            double normalizedMS = ((double)1 / noteLength) * 4;
            normalizedMS = (normalizedMS * ((double)tempo/60));
            normalizedMS *= 1000;
            msLength = (uint)normalizedMS;
            return (uint)normalizedMS;
        }
    }

}
