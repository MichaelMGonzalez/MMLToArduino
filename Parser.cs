using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLToArduino
{
    class Parser
    {
        const string VALIDNOTES = "abcdefg";
        const string VALIDNUMS = "0123456789";
        const string OCTAVEMODIFERS = "<>o";
        const string SHARPSANDFLATS = "+-#";
        const char REST = 'r';
        const char DOT = '.';
        const char TEMPOMODIFIER = 't';
        const char CHANGEDEFAULTLENGTH = 'l';

        private int index;
        private string mml;
        private ArrayList notes;

        private int octave;
        private int tempo;
        private int defaultNoteLength;
        private double a;

        public Parser(string mml)
        {
            this.mml = mml;
            notes = new ArrayList();
            index = 0;
            octave = 4;
            defaultNoteLength = 4;
            tempo = 120;
            a = Math.Pow(2, (double) 1/12 );
        }
        public ArrayList GetNotes() { return notes; }
        public void Parse()
        {
            while (AreBoundsValid())
            {
                ScanMML();
            }
            Console.WriteLine(AreBoundsValid());
            Console.WriteLine(index);
        }
        private void ScanMML()
        {
            MusicalElement potentialNote = IsNoteNext();
            if (potentialNote != null)
            {
                notes.Add(potentialNote);
                return;
            }
            potentialNote = IsRestNext();
            if (potentialNote != null)
            {
                notes.Add(potentialNote);
                return;
            }
            if (IsOctaveNext())
            {
                return;
            }
            if( IsNoteLengthNext() )
            {
                return;
            }
            if( IsTempoNext() )
            {
                return;
            }
            index++;
        }
        private bool IsNoteLengthNext()
        {
            bool retVal = (mml[index] == CHANGEDEFAULTLENGTH);
            if (retVal)
            {
                index++;
                int newDefaultLength = FindInteger();
                if (newDefaultLength == -1)
                    return false;
                defaultNoteLength = newDefaultLength;
            }
            return retVal;
        }
        private bool IsTempoNext()
        {
            bool retVal = (mml[index] == TEMPOMODIFIER);
            if(retVal)
            {
                index++;
                int newTempo = FindInteger();
                if (newTempo == -1)
                    return false;
                tempo = newTempo;
            }
            return retVal;
        }
        private bool IsOctaveNext()
        {
            bool retVal = false;
            for (int i = 0; i < OCTAVEMODIFERS.Length; i++)
            {
                if (OCTAVEMODIFERS[i] == mml[index])
                    retVal = true;
            }
            if (retVal == true)
            {
                index++;
                switch (mml[index-1])
                {
                    case 'o':
                        int newOctave = FindInteger();
                        if (newOctave == -1)
                            return false;
                        octave = newOctave;
                        break;
                    case '<':
                        octave--;
                        if (octave < 3)
                            octave = 8;
                        break;
                    case '>':
                        octave++;
                        if (octave > 8)
                            octave = 3;
                        break;
                }
            }
            return retVal;
        }
        private Rest IsRestNext()
        {
            Rest retVal = null;
            if (mml[index] == REST)
            {
                index++;
                int noteLength = FindInteger();
                bool isDotted = IsDotted();
                retVal = new Rest(noteLength);
                retVal.CalculateNoteDuration(tempo);
                retVal.SetIsDotted(isDotted);
            }
            return retVal;
        }
        private Note IsNoteNext()
        {
            Note retVal = null;
            bool isIndexANote = false;
            for (int i = 0; i < VALIDNOTES.Length; i++)
            {
                if (VALIDNOTES[i] == mml[index])
                    isIndexANote = true;
            }
            if (isIndexANote)
            {
                char note = mml[index];
                index++;
                Note.Semitone accidental = IsAccidental();
                int noteLength = FindInteger();
                bool isDotted = IsDotted();
                if (noteLength == -1)
                    noteLength = defaultNoteLength;
                if( accidental == Note.Semitone.natural )
                {
                    retVal = new Note(note, octave, noteLength);
                }
                else
                {
                    retVal = new Note(note, octave, noteLength, accidental);
                }
                retVal.SetIsDotted(isDotted);
                retVal.CalculateFrequency(a);
                retVal.CalculateNoteDuration(tempo);
            }
            return retVal;
        }
        private int FindInteger()
        {
            int retVal = -1;
            string parsedInt = ParseInteger();
            if( !parsedInt.Equals(""))
            {
                int.TryParse(parsedInt, out retVal);
            }
            return retVal;
        }
        private string ParseInteger()
        {
            string retVal = "";
            if (!AreBoundsValid())
                return retVal;
            bool isNextInteger = false;
            for (int i = 0; i < VALIDNUMS.Length; i++)
            {
                if (mml[index] == VALIDNUMS[i])
                    isNextInteger = true;
            }
            if (isNextInteger)
            {
                retVal = mml[index].ToString();
                index++;
            }
            else
                return retVal;
            return retVal + ParseInteger();
        }
        private bool IsDotted()
        {
            bool retVal = false;
            if (AreBoundsValid())
            {
                if (mml[index] == DOT)
                {
                    index++;
                    retVal = true;
                }
            }
            return retVal;
        }
        private Note.Semitone IsAccidental()
        {
            Note.Semitone retVal = Note.Semitone.natural;
            if (AreBoundsValid())
            {
                bool isAccidental = false;
                for( int i = 0; i < SHARPSANDFLATS.Length; i++ )
                {
                    if (mml[index] == SHARPSANDFLATS[i])
                        isAccidental = true;
                }
                if (isAccidental)
                {
                    switch (mml[index])
                    {
                        case '-':
                            retVal = Note.Semitone.flat;
                            break;
                        case '+':
                            retVal = Note.Semitone.sharp;
                            break;
                        case '#':
                            retVal = Note.Semitone.sharp;
                            break;
                    }
                    index++;
                }
            }
            return retVal;
        }

        private bool AreBoundsValid()
        {
            bool retVal = false;
            if (index < mml.Length)
                retVal = true;
            return retVal;
        }
    }
}
