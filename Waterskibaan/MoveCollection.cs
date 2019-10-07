using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public static class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> randomMoves = new List<IMoves>();
            Random random = new Random();

            int movesAmount = random.Next(0, 10);

            for (int i = 0; i < movesAmount; i++)
            {
                int randomMove = random.Next(1, 5);

                switch (randomMove)
                {
                    case 1:
                        randomMoves.Add(new JumpMove());
                        break;
                    case 2:
                        randomMoves.Add(new OneLegMove());
                        break;
                    case 3:
                        randomMoves.Add(new OneHandCableMove());
                        break;
                    case 4:
                        randomMoves.Add(new SaltoMove());
                        break;
                    case 5:
                        randomMoves.Add(new DoubleSalto());
                        break;
                }
            }

            return randomMoves;
        }

        public static int DoMove(int succesChance, int reward, string succesMessage)
        {
            int points = 0;

            Random r = new Random();

            if (r.Next(0, 100) <= succesChance)
            {
                points = reward;
                Console.WriteLine(succesMessage);
            }

            return points;
        }
    }

    public class JumpMove : IMoves
    {
        public int Move()
        {
            return MoveCollection.DoMove(90, 5, "Jumped! and earned 5 points!");
        }
    }

    public class OneLegMove : IMoves
    {
        public int Move()
        {
            return MoveCollection.DoMove(70, 10, "One leg move! Earned 10 points!");
        }
    }

    public class OneHandCableMove : IMoves
    {
        public int Move()
        {
            return MoveCollection.DoMove(50, 15, "One hand on cable! Earned 15 points!");
        }
    }

    public class SaltoMove : IMoves
    {
        public int Move()
        {
            return MoveCollection.DoMove(15, 30, "Wow! Salto! Earned 30 points!");
        }
    }

    public class DoubleSalto : IMoves
    {
        public int Move()
        {
            return MoveCollection.DoMove(5, 60, "Incredible job! Double salto!! Earned 60 points!");
        }
    }
}
