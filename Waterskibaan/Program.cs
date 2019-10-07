using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            TestOpdracht2();
            TestOpdracht3();
            List<IMoves> moves = MoveCollection.GetWillekeurigeMoves();
            foreach (IMoves move in moves)
                move.Move();
        }

        private static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();
            for (int i=0; i<9;i++)
            {
                kabel.NeemLijnInGebruik(new Lijn());
                kabel.VerschuifLijnen();
                Lijn l = kabel.VerwijderLijnVanKabel();
            }
            Console.WriteLine(kabel.ToString());
        }

        private static void TestOpdracht3()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            Console.WriteLine(lijnenVoorraad.VerwijderEersteLijn());    
            lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            Console.WriteLine(lijnenVoorraad.GetAantalLijnen());
            lijnenVoorraad.VerwijderEersteLijn();
            Console.WriteLine(lijnenVoorraad.ToString());
        }
    }
}
