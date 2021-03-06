﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLToArduino
{
    class Note : MusicalElement
    {
        private char note;
        private bool isSharp;
        private bool isFlat;
        private int octave;
        private uint frequency;
        
        private SortedDictionary<char, int> distanceFromA;

        public enum Semitone {
            flat,
            sharp,
            natural 
        }
        public Note(char note, int octave, int length)
        {
            this.note = note;
            this.octave = octave;
            noteLength = length;
            SetupDistanceFromA();
            msLength = 0;
            frequency = 0;
        }
        public Note(char note, int octave, int length, Semitone accidental )
            : this(note,octave,length)
        {
            switch (accidental)
            {
                case Semitone.flat:
                    isFlat = true;
                    break;
                case Semitone.sharp:
                    isSharp = true;
                    break;
            }
        }
        public override string ToString()
        {
            string retVal = "Note Type: " + Char.ToUpper(note);
            if (isSharp)
                retVal += "#";
            if (isFlat)
                retVal += "b";
            retVal += " Note Length: " + noteLength.ToString();
            if (isDotted)
                retVal += "+DOT";
            retVal += " Octave: " + octave.ToString();
            if( msLength > 0 )
                retVal += " MilliSecond Length: " + msLength.ToString();
            if( frequency > 0 )
                retVal += " Frequency: " + frequency.ToString();
            retVal += "\n";
            return retVal;
        }
        
        public uint CalculateFrequency(double a)
        {
            double freq = (octave - 4)*12;
            freq += distanceFromA[note];
            if (isSharp)
                freq++;
            if (isFlat)
                freq--;
            freq = (523.3 * Math.Pow(a, freq));
            frequency = (uint)Math.Floor(freq);
            return (uint)freq;
        }
        public uint GetFrequency()
        {
            return frequency;
        }
        private void SetupDistanceFromA()
        {
            distanceFromA = new SortedDictionary<char, int>();
            distanceFromA.Add('a', 9);
            distanceFromA.Add('b', 11);
            distanceFromA.Add('c', 0);
            distanceFromA.Add('d', 2);
            distanceFromA.Add('e', 4);
            distanceFromA.Add('f', 5);
            distanceFromA.Add('g', 7);
        }
        public override Type GetType()
        {
            return Type.Note;
        }
    }
}
