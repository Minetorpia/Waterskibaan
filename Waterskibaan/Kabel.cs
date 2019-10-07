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
                    lijn.PositieOpDeKabel = 0;
                    NeemLijnInGebruik(lijn);
                    _lijnen.RemoveLast();
                    break;
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lastLijn = null;
            if (_lijnen.Last().PositieOpDeKabel == 9)
            {
                lastLijn = _lijnen.Last();
                _lijnen.RemoveLast();
            }
            return lastLijn;
        }

        public override string ToString()
        {
            string returnString = "";
            foreach(Lijn lijn in _lijnen)
            {
                if (lijn != _lijnen.Last())
                    returnString += $"{lijn.PositieOpDeKabel}|";
                else
                    returnString += lijn.PositieOpDeKabel;
            }
            return returnString;
        }

    }
}
