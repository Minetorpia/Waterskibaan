using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Kabel
    {
        private LinkedList<Lijn> lijnen = new LinkedList<Lijn>();

        public LinkedList<Lijn> Lijnen { get => lijnen; set => lijnen = value; }

        public bool IsStartPositieLeeg()
        {
            if (Lijnen.Count >= 1)
            {
                if (Lijnen.First().PositieOpDeKabel == 0)
                    return false;
                else
                    return true;
            } else
            {
                return true;
            }
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if(IsStartPositieLeeg())
            {
                lijn.PositieOpDeKabel = 0;
                Lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn lijn in Lijnen)
            {
                if (lijn.PositieOpDeKabel != 9)
                    lijn.PositieOpDeKabel += 1;
                else
                {
                    /*Check if sporter still allowed another round*/
                    lijn.PositieOpDeKabel = 0;
                    lijn.Sporter.AantalRondenNogTeGaan--;
                    Lijnen.RemoveLast();
                    NeemLijnInGebruik(lijn);
                    break;
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lastLijn = null;
            if (Lijnen.Count > 1)
            {
                lastLijn = Lijnen.Last();
                if ((Lijnen.Last().PositieOpDeKabel == 9 || Lijnen.Last().PositieOpDeKabel == 0) && lastLijn.Sporter.AantalRondenNogTeGaan == 0)
                {
                    Lijnen.RemoveLast();
                    return lastLijn;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
            
            
        }

        public override string ToString()
        {
            string returnString = "";
            foreach(Lijn lijn in Lijnen)
            {
                if (lijn != Lijnen.Last())
                    returnString += $"{lijn.PositieOpDeKabel}({lijn.Sporter.Id}, {lijn.Sporter.AantalRondenNogTeGaan})|";
                else
                    returnString += $"{lijn.PositieOpDeKabel}({lijn.Sporter.Id}, {lijn.Sporter.AantalRondenNogTeGaan})";
            }
            return returnString;
        }

    }
}
