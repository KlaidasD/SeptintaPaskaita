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
                _streamWriter = new StreamWriter(_failoVieta,true);
            }

            private void AtidarytiSrautaIFailaPerrasant()
            {
            _streamWriter = new StreamWriter(_failoVieta, false);
            }

            public void IrasykDarbuotojaIFaila(Darbuotojas darbuotojas)
            {
                AtidarytiSrautaIFaila();
                _streamWriter.WriteLine($"{darbuotojas.AsmensKodas},{darbuotojas.Vardas},{darbuotojas.Pavarde}");
                _streamWriter.Close();
            }

            public void IstrinkDarbuotojaIsSaraso(Darbuotojas darbuotojas, List<Darbuotojas> darbuotojai)
            {
            darbuotojai.Remove(darbuotojas);
            Console.WriteLine("Sekmingai istrintas darbuotojas.");
            PerrasykDarbuotojusIFaila(darbuotojai);
            }
            
            public void IrasykDarbuotojusIFaila(List<Darbuotojas> darbuotojai)
            {
                AtidarytiSrautaIFaila();

                foreach (Darbuotojas darbuotojas in darbuotojai)
                {
                    _streamWriter.WriteLine($"{darbuotojas.AsmensKodas},{darbuotojas.Vardas},{darbuotojas.Pavarde}");
                }
                _streamWriter.Close();
            }

            private void PerrasykDarbuotojusIFaila(List<Darbuotojas> darbuotojai)
            {
            AtidarytiSrautaIFailaPerrasant();
            foreach (Darbuotojas darbuotojas in darbuotojai)
            {
                _streamWriter.WriteLine($"{darbuotojas.AsmensKodas},{darbuotojas.Vardas},{darbuotojas.Pavarde}");
            }
            _streamWriter.Close();
            }

            public List<Darbuotojas> SkaitytiDarbuotojuSarasa()
            {
                List<Darbuotojas> darbuotojai = new List<Darbuotojas>();

                _streamReader = new StreamReader(_failoVieta);
                string eilute;
                while ((eilute = _streamReader.ReadLine()) != null)
                {
                    string[] reiksmes = eilute.Split(',');
                    darbuotojai.Add(new Darbuotojas(long.Parse(reiksmes[0]), reiksmes[1], reiksmes[2]));
                }
                _streamReader.Close();
                return darbuotojai;
            }
        }
    }


