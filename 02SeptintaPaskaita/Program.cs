/*Užduotis 2: Produktų katalogo valdymo sistema
 * 
Sukurkite programą, kuri valdo produktų katalogą. Programa leis atlikti šias operacijas:
Pridėti naują produktą.
Rodyti visus produktus.
Ieškoti produkto pagal pavadinimą.
Atnaujinti produkto informaciją.
Ištrinti produktą.
Išsaugoti ir nuskaityti produktų duomenis iš failo.*/

using System;
using System.Collections.Generic;

namespace SeptintaPaskaita
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VeiksmaiSuFailais veiksmai = new VeiksmaiSuFailais("C:\\Users\\IDOMUSPC\\Documents\\prekes\\ManoProduktuSarasas.txt");

            List<Preke> prekes = veiksmai.SkaitytiPrekiuSarasa();

            while (true)
            {
                Console.WriteLine("Sveiki, programos funkcijos:" +
                    "\n1. Prideti preke i kataloga." +
                    "\n2. Parodyti visas prekes." +
                    "\n3. Ieskoti prekes pagal pavadinima" +
                    "\n4. Atnaujinti prekes informacija." +
                    "\n5. Istrinti preke." +
                    "\n6. Issaugoti ir nuskaityti prekiu duomenis." +
                    "\n7. Uzdaryti programa.");

                int ivestis;

                if (!int.TryParse(Console.ReadLine(), out ivestis))
                {
                    Console.WriteLine("Pasirinkimas negalimas.");
                }

                switch (ivestis)
                {
                    case 1:
                        Console.WriteLine("Kiek prekiu noresite ivesti?");
                        int pasirinkimas;
                        if (!int.TryParse(Console.ReadLine(), out pasirinkimas))
                        {
                            Console.WriteLine("Netinkamai ivestas prekiu kiekis.");
                        }
                        for (int i = 0; i < pasirinkimas; i++)
                        {
                            Console.WriteLine($"Iveskite {i + 1} prekes duomenis:");
                            VeiksmaiSuFailais.PridetiPreke(prekes);
                        }
                        break;
                    case 2:
                        VeiksmaiSuFailais.RodytiVisasPrekes(prekes);
                        break;
                    case 3:
                        VeiksmaiSuFailais.IeskotiPrekes(prekes);
                        break;
                    case 4:
                        VeiksmaiSuFailais.RedaguotiPreke(prekes);
                        break;
                    case 5:
                        VeiksmaiSuFailais.IstrintiPreke(prekes);
                        break;
                    case 6:
                        veiksmai.IrasykPrekesIFaila(prekes);
                        Console.WriteLine("Produktai sekmingai issaugoti.");
                        VeiksmaiSuFailais.RodytiVisasPrekes(prekes);
                        break;
                    case 7:
                        Console.WriteLine("Uzdaroma programa..");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas.");
                        break;
                }
            }
        }
    }
}
