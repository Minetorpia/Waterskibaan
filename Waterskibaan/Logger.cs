using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        public List<Sporter> Bezoekers { get; set; } = new List<Sporter>();
        public int FinishedRounds { get; set; }

        public void NieuweBezoekerHandler(NieuweBezoekerArgs args)
        {
            Bezoekers.Add(args.Sporter);        
        }

        public void PlayerFinishedHandler(SpelerFinishedArgs args)
        {
            FinishedRounds++;
        }
    }
}
