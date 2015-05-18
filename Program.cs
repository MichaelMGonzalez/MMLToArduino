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
            string mml = "t105l32>erer16.er16.crer16.gr4.r16.cr8r<gr8rer8rar16.br16.a+rar16.gr16>erg16rar16.frgr16.er16.crdrc-r8rcr8r<gr8rer8rar16.br16.a+rar16.gr16>erg16rar16.frgr16.er16.crdrc-r4rgrf+rfrd+r16.er16.<g+rarb+r16.ar>crdr8rgrf+rfrd+r16.er16.>cr16.crcr4r16.<grf+rfrd+r16.er16.<g+rarb+r16.ar>crdr8rd+r8rdr8rcr2r16.grf+rfrd+r16.er16.<g+rarb+r16.ar>crdr8rgrf+rfrd+r16.er16.>cr16.crcr4r16.<grf+rfrd+r16.er16.<g+rarb+r16.ar>crdr8rd+r8rdr8rcr4.r16.crcr16.cr16.crdr16.ercr16.<argr8.r>crcr16.cr16.crdrer2rcrcr16.cr16.crdr16.ercr16.<argr8.r>erer16.er16.crer16.gr4.r16.cr8r<gr8rer8rar16.br16.a+rar16.gr16>erg16rar16.frgr16.er16.crdrc-r8rcr8r<gr8rer8rar16.br16.a+rar16.gr16>erg16rar16.frgr16.er16.crdrc-r8rercr16.<gr8rg+r16.ar>fr16.fr<ar8.rbr16>ara16rar16grf16rercr16.<argr8.r>ercr16.<gr8rg+r16.ar>fr16.fr<ar8.rbr>fr16.frfr16erd16rcr4.r16.ercr16.<gr8rg+r16.ar>fr16.fr<ar8.rbr16>ara16rar16grf16rercr16.<argr8.r>ercr16.<gr8rg+r16.ar>fr16.fr<ar8.rbr>fr16.frfr16erd16rcr4.r16.crcr16.cr16.crdr16.ercr16.<argr8.r>crcr16.cr16.crdrer2rcrcr16.cr16.crdr16.ercr16.<argr8.r>erer16.er16.crer16.gr4.r16.ercr16.<gr8rg+r16.ar>fr16.fr<ar8.rbr16>ara16rar16grf16rercr16.<argr8.r>ercr16.<gr8rg+r16.ar>fr16.fr<ar8.rbr>fr16.frfr16erd16rc"; 
            Parser parser = new Parser(mml);
            parser.Parse();
            ArrayList notes = parser.GetNotes();
            MakeArduinoCode codeGen = new MakeArduinoCode();
            string noteArray = "notes";
            string noteLengthArray = "noteLength";
            string restConst = "REST";
            string restConstVal = "-1";
            codeGen.CreateVariable("int", "length", notes.Count.ToString());
            codeGen.CreateVariable("const int", restConst, restConstVal);
            codeGen.CreateArray("int", noteArray );
            codeGen.CreateArray("const PROGMEM int", noteLengthArray);
            int j = 0;
            foreach (MusicalElement note in notes)
            {
                //Console.Write(note);
                if (j == 512)
                {
                    codeGen.ChangeVariable("int", "length", "512");
                    break;
                }
                if (note.GetType() == MusicalElement.Type.Rest)
                    codeGen.AddElementToArray(noteArray, restConst);
                else
                {
                    Note newNote = (Note)note;
                    codeGen.AddElementToArray(noteArray, newNote.GetFrequency().ToString());
                }
                codeGen.AddElementToArray(noteLengthArray, note.GetMSLength().ToString());
                j++;
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
