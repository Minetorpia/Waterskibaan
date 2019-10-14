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
        public Tuple<byte, byte, byte> KledingKleur { get; set; }
        public Skies Skies { get; set; }
        public List<IMoves> Moves { get; set; }
        public int Id { get; private set; }
        public IMoves HuidigeMove;

        public Sporter(List<IMoves> moves, string kledingKleur)
        {
            Random r = new Random();
            Moves = moves;

            KledingKleur = new Tuple<byte, byte, byte>(Convert.ToByte(r.Next(0, 256)), Convert.ToByte(r.Next(0, 256)), Convert.ToByte(r.Next(0, 256)));
            Id = r.Next(0, 101);
        }

        public int Move()
        {
            int totalScore = 0;
            Random r = new Random();
            
            if(r.Next(0,5) == 0 && Moves.Count > 0)
            {
                    HuidigeMove = Moves[r.Next(0, Moves.Count)];
                    totalScore += HuidigeMove.Move();
            }

            return totalScore;
        }


    }
}
