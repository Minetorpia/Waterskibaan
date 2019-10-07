using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    abstract class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        /*public Color KledingKleur { get; set; }*/
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Moves = moves;
        }
    }
}
