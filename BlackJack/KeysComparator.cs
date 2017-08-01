using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class KeysComparator
    {

        internal string ReadKeyToString()
        {
            return Console.ReadKey().Key.ToString();
        }
        internal bool KeyIsSpacebar(string key)
        {
            return key == ConsoleKey.Spacebar.ToString();
        }
        internal bool KeyIsEscape(string key)
        {
            return key == ConsoleKey.Escape.ToString();
        }
        internal bool KeyIsEnter(string key)
        {
            return key == ConsoleKey.Enter.ToString();
        }
    }
}
