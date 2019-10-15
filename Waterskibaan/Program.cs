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
            Game game = new Game();
            game.Initialize();

        }

       /* private static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();
            for (int i=0; i<9;i++)
            {
                kabel.NeemLijnInGebruik(new Lijn());
                kabel.VerschuifLijnen();
                Lijn l = kabel.VerwijderLijnVanKabel();
            }
            Console.WriteLine(kabel.ToString());
        }*/

        /*private static void TestOpdracht3()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            Console.WriteLine(lijnenVoorraad.VerwijderEersteLijn());    
            lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            Console.WriteLine(lijnenVoorraad.GetAantalLijnen());
            lijnenVoorraad.VerwijderEersteLijn();
            Console.WriteLine(lijnenVoorraad.ToString());
        }


        private static void TestOpdracht4()
        {
            List<IMoves> moves = MoveCollection.GetWillekeurigeMoves();
            foreach (IMoves move in moves)
                move.Move();
        }


        private static void TestOpdracht8()
        {
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), "rood");

            sporter.Skies = new Skies();
            sporter.Zwemvest = new Zwemvest();

            Waterskibaan waterskibaan = new Waterskibaan();

            waterskibaan.SporterStart(sporter);
            waterskibaan.VerplaatsKabel();
        }

        private static void TestOpdracht9()
        {
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), "rood");
            Sporter sporter1 = new Sporter(MoveCollection.GetWillekeurigeMoves(), "blauw");


            WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
            wachtrijInstructie.SporterNeemPlaatsInRij(sporter);
            wachtrijInstructie.SporterNeemPlaatsInRij(sporter1);

            foreach (Sporter s in wachtrijInstructie.GetAlleSporters())
                Console.WriteLine(s.AantalRondenNogTeGaan);

            Console.WriteLine(wachtrijInstructie.ToString());
        }*/

    }

}
