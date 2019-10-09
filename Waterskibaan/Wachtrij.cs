using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public abstract class Wachtrij : IWachtrij
    {
        protected Queue<Sporter> sporters = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
            return sporters.ToArray().ToList();
        }

        public abstract void SporterNeemPlaatsInRij(Sporter sporter);


        public List<Sporter> SpottersVerlatenRij(int aantal)
        {
            List<Sporter> leavingSporters = new List<Sporter>();

            if (aantal > sporters.Count())
                throw new ArgumentException("Amount of sporters to leave is larger than amount of sporters in Queue");
            for (int i = 0; i < aantal; i++)
            {
                leavingSporters.Add(sporters.Dequeue());
            }

            return leavingSporters;
        }

        public override string ToString()
        {
            return $"Er zitten {sporters.Count()} in de {this.GetType().Name}";
        }
    }
}
