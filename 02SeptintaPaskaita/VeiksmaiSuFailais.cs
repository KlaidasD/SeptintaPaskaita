using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeptintaPaskaita
{
    /*Užduotis 2: Produktų katalogo valdymo sistema
 * 
Sukurkite programą, kuri valdo produktų katalogą. Programa leis atlikti šias operacijas:
Pridėti naują produktą.
Ištrinti produktą.
Rodyti visus produktus.
Ieškoti produkto pagal pavadinimą.
Atnaujinti produkto informaciją.
Išsaugoti ir nuskaityti produktų duomenis iš failo.*/

    public class VeiksmaiSuFailais
    {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private readonly string _failoVieta;

        public VeiksmaiSuFailais(string failoVieta)
        {
            _failoVieta = failoVieta;
        }


        private void AtidarytiSrautaIFaila()
        {
            _streamWriter = new StreamWriter(_failoVieta, true);
        }

        private void AtidarytiSrautaIFailaPerrasant()
        {
            _streamWriter = new StreamWriter(_failoVieta, false);
        }

        public void IrasykPrekeIFaila(Preke preke)
        {
            AtidarytiSrautaIFaila();
            _streamWriter.WriteLine($"{preke.EilesNr},{preke.Pavadinimas},{preke.Kaina}");
            _streamWriter.Close();
        }

        public void IstrinkProduktaIsKatalogo(Preke preke, List<Preke> prekes)
        {
            prekes.Remove(preke);
            Console.WriteLine("Sekmingai istrintas produktas.");

            for (int i = 0; i < prekes.Count; i++)
            {
                prekes[i].EilesNr = i + 1;
            }

            PerrasykPrekesIFaila(prekes);
        }

        public void IrasykPrekesIFaila(List<Preke> prekes)
        {
            AtidarytiSrautaIFaila();

            foreach (Preke preke in prekes)
            {
                _streamWriter.WriteLine($"{preke.EilesNr},{preke.Pavadinimas},{preke.Kaina}");
            }
            _streamWriter.Close();
        }

        private void PerrasykPrekesIFaila(List<Preke> prekes)
        {
            AtidarytiSrautaIFailaPerrasant();
            foreach (Preke preke in prekes)
            {
                _streamWriter.WriteLine($"{preke.EilesNr},{preke.Pavadinimas},{preke.Kaina}");
            }
            _streamWriter.Close();
        }

        public List<Preke> SkaitytiPrekiuSarasa()
        {
            List<Preke> prekes = new List<Preke>();

            _streamReader = new StreamReader(_failoVieta);
            string eilute;
            while ((eilute = _streamReader.ReadLine()) != null)
            {
                string[] reiksmes = eilute.Split(',');
                prekes.Add(new Preke(int.Parse(reiksmes[0]), reiksmes[1], double.Parse(reiksmes[2])));
            }
            _streamReader.Close();
            return prekes;
        }

       

        public static void PridetiPreke(List<Preke> prekes)
        {
            Console.WriteLine("Iveskite pavadinima: ");
            string pavadinimas = Console.ReadLine();

            foreach (Preke x in prekes)
            {
                if (x.Pavadinimas == pavadinimas)
                {
                    Console.WriteLine("Preke su tokiu pavadinimu jau yra sarase.");
                }
            }

            Console.WriteLine("Iveskite prekes kaina: ");
            double kaina;

            if (!double.TryParse(Console.ReadLine(), out kaina))
            {
                Console.WriteLine("Netinkamai ivesta prekes kaina. (Naudoti formata xx.xx");
                return;
            }

            int eilesNr = prekes.Count + 1;

            Preke preke = new Preke(eilesNr, pavadinimas, kaina);
            prekes.Add(preke);
            Console.WriteLine($"Sekmingai prideta preke su siais duomenimis: {preke}");
        }
      
       

        public static void RodytiVisasPrekes(List<Preke> prekes)
        {
            Console.WriteLine("Visos prekes:");

            foreach (Preke x in prekes)
            {
                Console.WriteLine(x);
            }
        }


        public static void IstrintiPreke(List<Preke> prekes)
        {
            Console.WriteLine("Spausdinamas prekiu sarasas..");
            RodytiVisasPrekes(prekes);
            Console.WriteLine("Iveskite prekes eiles numeri, kuria norite pasalinti: ");
            int ivestis;

            if(!int.TryParse(Console.ReadLine(), out ivestis))
            {
                Console.WriteLine("Netinkama ivestis.");
            }

            Preke istrinama = null;

            foreach (Preke x in prekes)
            {
                if (x.EilesNr == ivestis)
                {
                    istrinama = x;
                    break;
                }
            }

            if (istrinama != null)
            {
                    prekes.Remove(istrinama);
                    Console.WriteLine("Preke sekmingai istrinta.");

                    for (int i = 0; i < prekes.Count; i++)
                    {
                        prekes[i].EilesNr = i + 1;
                    }
            }
            
            else
            {
                Console.WriteLine("Preke nerasta.");
                return;
            }
        }

        public static void IeskotiPrekes(List<Preke> prekes)
        {
            Console.WriteLine("Iveskite ieskomos prekes pavadinima:");

            string ivestis = Console.ReadLine().ToLower();

            List<Preke> rastos = new List<Preke>();

            foreach (Preke x in prekes)
            {
                if (x.Pavadinimas.ToLower().Contains(ivestis))
                {
                    rastos.Add(x);
                }
            }
            if (rastos.Count > 0)
            {
                Console.WriteLine("Rastos prekes:");
                foreach (Preke x in rastos)
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                Console.WriteLine("Prekes pagal jusu nurodyta pavadinima neradome.");
            }
        }

        public static void RedaguotiPreke(List<Preke> prekes)
        {
            Console.WriteLine("Atspausdinamas prekiu sarasas..");
            RodytiVisasPrekes(prekes);
            Console.Write("Iveskite prekes pavadinima, kuria norite redaguoti");
            string ivestis = Console.ReadLine();

            Preke redaguojama = null;

            foreach (Preke x in prekes)
            {
                if (x.Pavadinimas == ivestis)
                {
                    redaguojama = x;
                    break;
                }
            }

            if (redaguojama != null)
            {
                Console.Write("Iveskite nauja pavadinima: ");
                redaguojama.Pavadinimas = Console.ReadLine();

                Console.Write("Iveskite nauja kaina: ");
                double kaina;
                if(!double.TryParse(Console.ReadLine(), out kaina))
                {
                    Console.WriteLine("Netinkamai ivesta kaina..");
                }
                redaguojama.Kaina = kaina;
            }
            else
            {
                Console.WriteLine("Preke nerasta.");
            }
        }
    }
}
