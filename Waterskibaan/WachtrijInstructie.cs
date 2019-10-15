using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {
        private const int MAX_LENGTE_RIJ = 100;

        public override void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (sporters.Count() < MAX_LENGTE_RIJ)
                sporters.Enqueue(sporter);
        }

        public void NieuweBezoekerHandler(NieuweBezoekerArgs args)
        {
            if (args.Sporter != null)
                SporterNeemPlaatsInRij(args.Sporter);
        }

        public List<Sporter> GetUninstructedSporters()
        {
            List<Sporter> uninstructedSporters = new List<Sporter>();

            for (int i = 0; i < 5; i++)
            {
                if (sporters.Count() > 0)
                    uninstructedSporters.Add(sporters.Dequeue());
                else
                {
                    Console.WriteLine("Geen klaarstaande spelers");
                    break;
                }
            }

            return uninstructedSporters;
        }
    }
}
