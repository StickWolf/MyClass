using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundUtils;

namespace PianoKeyboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var keyInfo = Console.ReadKey();
                ABunchaSounds.PlayByKey(keyInfo.KeyChar, 3);
            }
        }
    }
}
