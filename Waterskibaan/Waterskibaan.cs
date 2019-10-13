using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        private LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
        private Kabel kabel = new Kabel();
        public LijnenVoorraad LijnenVoorraad { get; private set; }
        public Kabel Kabel {
            get { return kabel; }
            private set { kabel = value; } }

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }


        public void VerplaatsKabel()
        {
            Lijn removableLijn = kabel.VerwijderLijnVanKabel();

            if (removableLijn != null)
                lijnenVoorraad.LijnToevoegenAanRij(removableLijn);

            kabel.VerschuifLijnen();
        }


        public override string ToString()
        {
            string returnString = "";
            returnString += "--- Overzicht Waterskibaan:---\n";
            returnString += lijnenVoorraad.ToString();
            returnString += "\n" + kabel.ToString();
            returnString += "\n------------------------------";
            return returnString;
        }


        public void SporterStart(Sporter sp)
        {
            if (kabel.IsStartPositieLeeg())
            {
                if (sp.Zwemvest == null || sp.Skies == null)
                    throw new Exception("Zwemvest or Skies is null");

                Lijn nieuweLijn = lijnenVoorraad.VerwijderEersteLijn();
                

                Random r = new Random();
                sp.AantalRondenNogTeGaan = r.Next(1,3);
                nieuweLijn.Sporter = sp;

                kabel.NeemLijnInGebruik(nieuweLijn);
            }
        }
    }
}
