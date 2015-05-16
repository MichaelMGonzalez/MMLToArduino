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
            Console.WriteLine(mml);
            Parser parser = new Parser(mml);
            parser.Parse();
            ArrayList notes = parser.GetNotes();
            foreach (MusicalElement note in notes)
            {
                Console.WriteLine(note);
            }
        }
    }
}
