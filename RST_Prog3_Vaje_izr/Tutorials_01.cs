using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RST_Prog3_Vaje_izr
{
    public class Tutorials_01
    {
        /// <summary>
        /// Pripravite razred Index z ustreznimi lastnostmi, predvsem naj vsebuje seznam predmetov. 
        /// Posamezen predmet naj bo instanca razreda Subject, ki ima lastnosti Name in Grade.
        /// Lastnost Grade naj dovoli samo vrednosti med 5 in 10. 
        /// Če poskušate nastaviti drugo vrednost, 
        /// naj se samodejno popravi na najbližjo dovoljeno vrednost.
        /// V razred Indeks dodajte še lastnost PovprecnaOcena kot samo za branje, 
        /// ki izračuna povprečje ocen predmetov.
        /// </summary>
        public static void Exercise_324()
        {
            Predmet programiranje3 = new Predmet("Programiranje 3");
            programiranje3.Ocena = 10;

            Predmet modeliranje = new Predmet("3D Modeliranje");
            modeliranje.Ocena = 10;

            Index index = new Index(0);
            index.Predmeti.Add(programiranje3);
            index.Predmeti.Add(modeliranje);

            Console.WriteLine(index);

            Console.WriteLine($"Povprečje ocen študenta {index.VpisnaStevilka} je {index.PovprecnaOcena:0.00}");

            Console.ReadLine();
        }
    }


    /// <summary>
    /// Razred, ki predstavlja študentski indeks.
    /// </summary>
    public class Index
    {
        public int VpisnaStevilka { get; }
        public List<Predmet> Predmeti { get; set; } = new List<Predmet>();

        public Index(int vs)
        {
            VpisnaStevilka = vs;
        }

        public override string ToString()
        {
            string izpis = $"{VpisnaStevilka} \n";

            foreach (Predmet predmet in this.Predmeti)
            {
                izpis += $"{predmet.ToString()} \n";
            }

            return izpis;
        }

        public double PovprecnaOcena
        {
            get
            {
                return Predmeti.Average(x => x.Ocena);
            }
        }
    }

    public class Predmet
    {
        public string Ime { get; }

        private int ocena;
        public int Ocena
        {
            get
            {
                return ocena;
            }
            set
            {
                if (value < 5)
                {
                    ocena = 5;
                }
                else if (value > 10)
                {
                    ocena = 10;
                }
                else
                {
                    ocena = value;
                }
            }
        }

        public Predmet(string ime)
        {
            Ime = ime;
        }

        public override string ToString()
        {
            return $"{this.Ime} : {this.Ocena}";
        }
    }
}
