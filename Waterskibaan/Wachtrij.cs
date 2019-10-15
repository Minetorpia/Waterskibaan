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


        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> leavingSporters = new List<Sporter>();

            for (int i = 0; i < aantal; i++)
            {
                if (i < aantal && sporters.Count > 0)
                    leavingSporters.Add(sporters.Dequeue());
                else
                    break;
            }

            return leavingSporters;
        }

        public override string ToString()
        {
            return $"Er zitten {sporters.Count()} in de {this.GetType().Name}";
        }
    }
}
