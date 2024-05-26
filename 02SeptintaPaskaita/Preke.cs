using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptintaPaskaita
{
    /*Užduotis 2: Produktų katalogo valdymo sistema
 * 
Sukurkite programą, kuri valdo produktų katalogą. Programa leis atlikti šias operacijas:
Pridėti naują produktą.
Rodyti visus produktus.
Ieškoti produkto pagal pavadinimą.
Atnaujinti produkto informaciją.
Ištrinti produktą.
Išsaugoti ir nuskaityti produktų duomenis iš failo.*/

    public class Preke
    {
        public int EilesNr;
        public string Pavadinimas;
        public double Kaina;
        

        public Preke(int eilesNr, string prekesPav, double aKaina)
        {
            EilesNr = eilesNr;
            Pavadinimas = prekesPav;
            Kaina = aKaina;
        }

        public override string ToString()
        {
            return $"Eiles numeris: {EilesNr} Preke:{Pavadinimas}, Kaina:{Kaina}";
        }
    }
}
