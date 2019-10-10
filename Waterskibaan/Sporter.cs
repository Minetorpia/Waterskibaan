using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public string KledingKleur { get; set; }
        public Skies Skies { get; set; }
        public List<IMoves> Moves { get; set; }
        public int Id { get; private set; }

        public Sporter(List<IMoves> moves, string kledingKleur)
        {

            Moves = moves;
            KledingKleur = kledingKleur;
            Zwemvest = new Zwemvest();
            Skies = new Skies();

            Random r = new Random();
            Id = r.Next(0, 10);
        }
    }
}
