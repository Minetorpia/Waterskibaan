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

    }
}
