using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptintaPaskaita
{
    /*Užduotis 1: Sukurkite programą, kuri valdo darbuotojų duomenis.
        * Programa leis pridėti darbuotojus, rodyti visus darbuotojus ir išsaugoti bei nuskaityti darbuotojų duomenis iš failo.
       Pridėti darbuotoją į sąrašą
       Pašalinti darbuotoją iš sąrašo
       Parodyti visus darbuotojus*/

    public class Darbuotojas
    {
        public long AsmensKodas;
        public string Vardas;
        public string Pavarde;

        public Darbuotojas(long asmKodas, string vardas, string pavarde)
        {
            AsmensKodas = asmKodas;
            Vardas = vardas;
            Pavarde = pavarde;
        }

        public override string ToString()
        {
            return $"Asmens kodas:{AsmensKodas}, Vardas:{Vardas}, Pavarde:{Pavarde}";
        }
    }
}
