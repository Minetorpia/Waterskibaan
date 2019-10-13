using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Game
    {
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public delegate void LijnenVerplaatstHandler();

        private Waterskibaan waterskibaan = new Waterskibaan();

        private static Timer gameTimer;
        private static Timer instructieTimer;
        private static Timer instructieAfgelopenTimer;
        
        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        private WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        private InstructieGroep instructieGroep = new InstructieGroep();
        private WachtrijStarten wachtrijStarten = new WachtrijStarten();


        public void Initialize()
        {
            NieuweBezoeker += wachtrijInstructie.NieuweBezoekerHandler;
            InstructieAfgelopen += instructieGroep.InstructieAfgelopenHandler;

            gameTimer = CreateAndSetTimer(3000, OnTimedEventNewBezoeker);
            instructieTimer = CreateAndSetTimer(20000, OnTimedEventInstructieAfgelopen);
            instructieAfgelopenTimer = CreateAndSetTimer(4000, OnTimedEventVerplaatsLijnen);

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.ReadLine();
            gameTimer.Stop();
            gameTimer.Dispose();
            instructieTimer.Stop();
            instructieTimer.Dispose();
            instructieAfgelopenTimer.Stop();
            instructieAfgelopenTimer.Dispose();


            Console.WriteLine("Terminating the application...");
        }


        public Timer CreateAndSetTimer(int ms, ElapsedEventHandler elapsedEventHandler)
        {
            Timer timer = new Timer(ms/10);
            timer.Elapsed += elapsedEventHandler;
            timer.AutoReset = true;
            timer.Enabled = true;

            return timer;
        }


        public void OnTimedEventNewBezoeker(object source, ElapsedEventArgs e)
        {
            NieuweBezoekerArgs nieuweBezoekerArgs = new NieuweBezoekerArgs();
            nieuweBezoekerArgs.Sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), "kleur");
            NieuweBezoeker(nieuweBezoekerArgs);
        }


        public void OnTimedEventInstructieAfgelopen(object source, ElapsedEventArgs e)
        {
            List<Sporter> uninstructedSporters = wachtrijInstructie.GetUninstructedSporters();

            if (uninstructedSporters.Count > 0)
            {
                InstructieAfgelopenArgs instructieAfgelopenArgs = new InstructieAfgelopenArgs();
                instructieAfgelopenArgs.NewUninstructedSpelers = uninstructedSporters;

                // Firing event, should add new sporters to instructieAfgelopenArgs.InstructedSporters
                InstructieAfgelopen(instructieAfgelopenArgs);

                if (instructieAfgelopenArgs.InstructedSporters != null)
                {
                    foreach (Sporter sporter in instructieAfgelopenArgs.InstructedSporters)
                    {
                        wachtrijStarten.SporterNeemPlaatsInRij(sporter);
                    }
                }
                
            } 
        }

        
        public void OnTimedEventVerplaatsLijnen(object source, ElapsedEventArgs e)
        {
            waterskibaan.VerplaatsKabel();
            if (waterskibaan.Kabel.IsStartPositieLeeg() && wachtrijStarten.GetAlleSporters().Count > 0)
            {
                PrintGameStatus();
                Sporter instructedSporter = wachtrijStarten.SportersVerlatenRij(1)[0];
                instructedSporter.Skies = new Skies();
                instructedSporter.Zwemvest = new Zwemvest();
                waterskibaan.SporterStart(instructedSporter);
            }


            /*LijnenVerplaatst();*/
        }

        public void PrintGameStatus()
        {
            Console.WriteLine(wachtrijInstructie);
            Console.WriteLine(instructieGroep);
            Console.WriteLine(wachtrijStarten);
            int total = wachtrijInstructie.GetAlleSporters().Count + instructieGroep.GetAlleSporters().Count + wachtrijStarten.GetAlleSporters().Count;
            Console.WriteLine($"Totaal: {total}" + "\n");
        }



    }
}
