using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Sporter : IMoves
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public string KledingKleur { get; set; }
        public Skies Skies { get; set; }
        public List<IMoves> Moves { get; set; }
        public int Id { get; private set; }
        public IMoves HuidigeMove;

        public Sporter(List<IMoves> moves, string kledingKleur)
        {

            Moves = moves;
            KledingKleur = kledingKleur;

            Random r = new Random();
            Id = r.Next(0, 10);
        }

        public int Move()
        {
            int totalScore = 0;
            if (Moves.Count > 0)
            {
                Random r = new Random();
                HuidigeMove = Moves[r.Next(0, Moves.Count)];
                totalScore += HuidigeMove.Move();
            }

            return totalScore;
        }
    }
}
