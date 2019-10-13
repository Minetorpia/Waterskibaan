using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij
    {
        private const int MAX_LENGTE_RIJ = 5;

        public override void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (sporters.Count() < MAX_LENGTE_RIJ)
                sporters.Enqueue(sporter);
        }

        public void InstructieAfgelopenHandler(InstructieAfgelopenArgs args)
        {
            if (sporters.Count() > 0)
            {
                args.InstructedSporters = SportersVerlatenRij(5);
            }

            foreach (Sporter sporter in args.NewUninstructedSpelers)
            {
                SporterNeemPlaatsInRij(sporter);
            } 

        }
    }
}
