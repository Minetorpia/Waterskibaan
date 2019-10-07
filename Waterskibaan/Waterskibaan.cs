using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        private LijnenVoorraad lijnenVoorraad;
        private Kabel kabel;

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }

        }


        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            lijnenVoorraad.LijnToevoegenAanRij(kabel.VerwijderLijnVanKabel());
        }


        public override string ToString()
        {
            string returnString = "";
            returnString += "--- Overzicht Waterskibaan:---\n";
            returnString += lijnenVoorraad.ToString();
            returnString += kabel.ToString();
            returnString += "------------------------------";
            return returnString;
        }


        public void SporterStart(Sporter sp)
        {
            if(kabel.IsStartPositieLeeg())
            {
                Lijn nieuweLijn = lijnenVoorraad.VerwijderEersteLijn();
                nieuweLijn.Sporter = sp;

                Random r = new Random();
                int aantalRondes = r.Next(1, 2);

                kabel.NeemLijnInGebruik(nieuweLijn);
            }
        }
    }
}
