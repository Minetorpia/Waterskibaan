using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Sporter : IMoves
    {
        public int AantalRondenNogTeGaan { get; set; } = -1;
        public Zwemvest Zwemvest { get; set; }
        public Tuple<byte, byte, byte> KledingKleur { get; set; }
        public Skies Skies { get; set; }
        public List<IMoves> Moves { get; set; }
        public int Id { get; set; }
        public IMoves HuidigeMove;
        public int Score { get; set; }
        public Random Random { get; set; }

        public Sporter(List<IMoves> moves, string kledingKleur)
        {
            Random = new Random();
            Moves = moves;

            KledingKleur = new Tuple<byte, byte, byte>(Convert.ToByte(Random.Next(0, 256)), Convert.ToByte(Random.Next(0, 256)), Convert.ToByte(Random.Next(0, 256)));
        }

        public int Move()
        {
            int totalScore = 0;
            
            if(Random.Next(0,4) == 0 && Moves.Count > 0)
            {
                    HuidigeMove = Moves[Random.Next(0, Moves.Count)];
                    totalScore += HuidigeMove.Move();
            } else
            {
                HuidigeMove = null;
            }
            Score += totalScore;

            return totalScore;
        }

        public string GetMoveNaam()
        {
            return "Is speler";
        }
    }
}
