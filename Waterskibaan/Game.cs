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

        private static Timer gameTimer;
        private Waterskibaan waterskibaan = new Waterskibaan();

        public void Initialize()
        {
            SetTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.ReadLine();
            gameTimer.Stop();
            gameTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        public void SetTimer()
        {
            gameTimer = new Timer(500);
            gameTimer.Elapsed += OnTimedEvent;
            gameTimer.AutoReset = true;
            gameTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Random r = new Random();
            waterskibaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves(), "kleur"));
            waterskibaan.VerplaatsKabel();
            Console.WriteLine(waterskibaan.ToString());
        }
    }
}
