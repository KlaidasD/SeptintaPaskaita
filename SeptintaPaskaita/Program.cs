using System;
using System.Security.Cryptography.X509Certificates;

namespace SeptintaPaskaita
{
    public class Program
    {

        /*Užduotis 1: Sukurkite programą, kuri valdo darbuotojų duomenis.
         * Programa leis pridėti darbuotojus, rodyti visus darbuotojus ir išsaugoti bei nuskaityti darbuotojų duomenis iš failo.
         * 
        Pridėti darbuotoją į sąrašą
        Pašalinti darbuotoją iš sąrašo
        Parodyti visus darbuotojus*/

        public static void Main(string[] args)
        {
            VeiksmaiSuFailais veiksmai = new VeiksmaiSuFailais("C:\\Users\\IDOMUSPC\\Documents\\darbuotojai\\ManoDarbuotojuSarasas.txt");
            List<Darbuotojas> darbuotojai = veiksmai.SkaitytiDarbuotojuSarasa();

            while (true)
            {
                Console.WriteLine("Sveiki, programos funkicjos:\n1.Prideti darbuotoja i sarasa.\n2.Pasalinti darbuotoja is saraso.\n3.Parodyti visus darbuotojus.\n4.Uzdaryti programa.");

                int ivestis;

                if (!int.TryParse(Console.ReadLine(), out ivestis))
                {
                    Console.WriteLine("Pasirinkimas negalimas.");
                }

                if (ivestis == 1)
                {
                    Console.WriteLine("Pradedama darbuotojo sukurimo funkcija..iveskite reikalingus duomenis kai ju paprasys.\nKiek darbuotoju norite prideti?");
                    int kiekis;
                    if (!int.TryParse(Console.ReadLine(), out kiekis))
                    {
                        Console.WriteLine("Neteisingai ivestas darbuotoju kiekis.");
                    }

                    for (int i = 0; i < kiekis; i++)
                    {
                        Console.WriteLine($"Iveskite {i + 1} darbuotojo duomenis.");
                        Darbuotojas nDarbuotojas = SukurtiDarbuotoja();
                        veiksmai.IrasykDarbuotojaIFaila(nDarbuotojas);
                    }
                    Console.WriteLine($"Sekmingai pridetas(-i) darbuotojas(-ai).");
                }

                if (ivestis == 2)
                {
                    Console.WriteLine("Pradedama darbuotojo istrynimo funkcija.");

                    darbuotojai = veiksmai.SkaitytiDarbuotojuSarasa();

                    foreach (Darbuotojas darbuotojas in darbuotojai)
                    {
                        Console.WriteLine(darbuotojas);
                    }
                    Console.WriteLine("Kuri darbuotoja norite istrinti? (iveskite asmens koda)");

                    long istrinamas;

                    if (!long.TryParse(Console.ReadLine(), out istrinamas))
                    {
                        Console.WriteLine("Ivestas neteisingas asmens kodas.");
                    }

                    foreach(Darbuotojas x in darbuotojai)
                    {
                        if(istrinamas == x.AsmensKodas)
                        {
                            veiksmai.IstrinkDarbuotojaIsSaraso(x, darbuotojai);
                            break;
                        }
                    }
                }

                if(ivestis == 3)
                {
                    Console.WriteLine("Visi darbuotojai:");

                    darbuotojai = veiksmai.SkaitytiDarbuotojuSarasa();

                    foreach(Darbuotojas darbuotojas in darbuotojai)
                    {
                        Console.WriteLine(darbuotojas);
                    }
                }

                if(ivestis == 4)
                {
                    Console.WriteLine("Uzdaroma programa..");
                    Environment.Exit(0);
                }
            }
        }

        public static Darbuotojas SukurtiDarbuotoja()
        {
            Console.WriteLine("Asm. Kodas: ");
            long asmKodas = long.Parse(Console.ReadLine());
            Console.WriteLine("Vardas: ");
            string vardas = (Console.ReadLine());
            Console.WriteLine("Pavarde: ");
            string pavarde = (Console.ReadLine());
            return new Darbuotojas(asmKodas, vardas, pavarde);
        }
    }
}

