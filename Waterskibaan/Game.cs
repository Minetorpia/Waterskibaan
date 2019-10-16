using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public delegate void PlayerRoundFinishedHandler(SpelerFinishedArgs args);

    public class Game
    {
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public delegate void LijnenVerplaatstHandler();

        private Waterskibaan waterskibaan = new Waterskibaan();
        public Logger Logger { get; set; } = new Logger();

        public Timer gameTimer;
        public Timer instructieTimer;
        public Timer instructieAfgelopenTimer;
        
        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        private WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        private InstructieGroep instructieGroep = new InstructieGroep();
        private WachtrijStarten wachtrijStarten = new WachtrijStarten();

        public WachtrijInstructie WachtrijInstructie { get => wachtrijInstructie; private set => wachtrijInstructie = value; }
        public InstructieGroep InstructieGroep { get => instructieGroep; private set => instructieGroep = value; }
        public WachtrijStarten WachtrijStarten { get => wachtrijStarten; private set => wachtrijStarten = value; }
        public Waterskibaan Waterskibaan { get => waterskibaan; private set => waterskibaan = value; }

        public void Initialize()
        {
            NieuweBezoeker += WachtrijInstructie.NieuweBezoekerHandler;
            NieuweBezoeker += Logger.NieuweBezoekerHandler;

            InstructieAfgelopen += InstructieGroep.InstructieAfgelopenHandler;

            waterskibaan.Kabel.PlayerRoundFinished += Logger.PlayerFinishedHandler;

            gameTimer = CreateAndSetTimer(3000, OnTimedEventNewBezoeker);
            instructieTimer = CreateAndSetTimer(20000, OnTimedEventInstructieAfgelopen);
            instructieAfgelopenTimer = CreateAndSetTimer(4000, OnTimedEventVerplaatsLijnen);

            Console.WriteLine("Terminating the application...");
        }


        public Timer CreateAndSetTimer(int ms, ElapsedEventHandler elapsedEventHandler)
        {
            Timer timer = new Timer(ms);
            timer.Elapsed += elapsedEventHandler;
            timer.AutoReset = true;
            timer.Enabled = true;

            return timer;
        }


        public void OnTimedEventNewBezoeker(object source, ElapsedEventArgs e)
        {
            NieuweBezoekerArgs nieuweBezoekerArgs = new NieuweBezoekerArgs();
            nieuweBezoekerArgs.Sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), "kleur");
            nieuweBezoekerArgs.Sporter.Id = Logger.Bezoekers.Count() + 1;
            NieuweBezoeker(nieuweBezoekerArgs);
        }


        public void OnTimedEventInstructieAfgelopen(object source, ElapsedEventArgs e)
        {
            List<Sporter> uninstructedSporters = WachtrijInstructie.GetUninstructedSporters();

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
                        WachtrijStarten.SporterNeemPlaatsInRij(sporter);
                    }
                }
                
            } 
        }

        
        public void OnTimedEventVerplaatsLijnen(object source, ElapsedEventArgs e)
        {
            Waterskibaan.VerplaatsKabel();
            if (Waterskibaan.Kabel.IsStartPositieLeeg() && WachtrijStarten.GetAlleSporters().Count > 0)
            {
                PrintGameStatus();
                Sporter instructedSporter = WachtrijStarten.SportersVerlatenRij(1)[0];
                instructedSporter.Skies = new Skies();
                instructedSporter.Zwemvest = new Zwemvest();
                Waterskibaan.SporterStart(instructedSporter);
            }


            /*LijnenVerplaatst();*/
        }

        public void PrintGameStatus()
        {
            Console.WriteLine(WachtrijInstructie);
            Console.WriteLine(InstructieGroep);
            Console.WriteLine(WachtrijStarten);
            int total = WachtrijInstructie.GetAlleSporters().Count + InstructieGroep.GetAlleSporters().Count + WachtrijStarten.GetAlleSporters().Count;
            Console.WriteLine($"Totaal: {total}" + "\n");
        }
    }
}
