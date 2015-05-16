using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLToArduino
{
    class Program
    {
        static void Main(string[] args)
        {
            string mml = "r1t200l16>eg+c+e<an61g+n61af+ea>eg+c+e<an61g+n61af+ear8a4.";
            Parser parser = new Parser(mml);
            parser.Parse();
            ArrayList notes = parser.GetNotes();
            MakeArduinoCode codeGen = new MakeArduinoCode();
            string noteArray = "notes";
            string noteLengthArray = "noteLength";
            codeGen.CreateVariable("int", "length", notes.Count.ToString());
            codeGen.CreateArray("int", noteArray );
            codeGen.CreateArray("int", noteLengthArray);
            foreach (MusicalElement note in notes)
            {
                if (note.GetType() == MusicalElement.Type.Rest)
                    codeGen.AddElementToArray(noteArray, "-1");
                else
                {
                    Note newNote = (Note)note;
                    codeGen.AddElementToArray(noteArray, newNote.GetFrequency().ToString());
                }
                codeGen.AddElementToArray(noteLengthArray, note.GetMSLength().ToString());
            }
            codeGen.FinishArray(noteArray);
            codeGen.FinishArray(noteLengthArray);
            ArrayList generatedCode = codeGen.GetAllDefinedVariables();
            for(int i = 0; i < generatedCode.Count; i++ )
            {
                Console.WriteLine((string)generatedCode[i]);
            }
        }
    }
}
