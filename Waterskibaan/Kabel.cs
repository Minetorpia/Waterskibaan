using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count >= 1)
            {
                if (_lijnen.First().PositieOpDeKabel == 0)
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
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel != 9)
                    lijn.PositieOpDeKabel += 1;
                else
                {
                    /*Check if sporter still allowed another round*/
                    lijn.PositieOpDeKabel = 0;
                    lijn.Sporter.AantalRondenNogTeGaan--;
                    _lijnen.RemoveLast();
                    NeemLijnInGebruik(lijn);
                    break;
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lastLijn = _lijnen.Last();
            if ((_lijnen.Last().PositieOpDeKabel == 9 || _lijnen.Last().PositieOpDeKabel == 0) && lastLijn.Sporter.AantalRondenNogTeGaan == 0)
            {
                _lijnen.RemoveLast();
                return lastLijn;
            } else
            {
                return null;
            }
            
        }

        public override string ToString()
        {
            string returnString = "";
            foreach(Lijn lijn in _lijnen)
            {
                if (lijn != _lijnen.Last())
                    returnString += $"{lijn.PositieOpDeKabel}({lijn.Sporter.Id}, {lijn.Sporter.AantalRondenNogTeGaan})|";
                else
                    returnString += $"{lijn.PositieOpDeKabel}({lijn.Sporter.Id}, {lijn.Sporter.AantalRondenNogTeGaan})";
            }
            return returnString;
        }

    }
}
