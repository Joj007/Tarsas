using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huhuuuu
{
    public class Ösvény
    {
        List<char> osveny;
        static int osvenyekSzama;
        int index;
        int countM;
        int countE;
        int countV;

        public Ösvény(List<char> osveny)
        {
            this.osveny = osveny;
            osvenyekSzama++;
            index = osvenyekSzama;
            foreach (char c in osveny)
            {
                if (c == 'M')
                    countM++;
                else if(c == 'E')
                    countE++;
                else if (c == 'V')
                    countV++;
            }
        }


        public List<char> Osveny { get => osveny;}
        public int Index { get => index;}
        public static int OsvenyekSzama { get => osvenyekSzama;}
        public int CountM { get => countM;}
        public int CountE { get => countE;}
        public int CountV { get => countV;}
    }
}
