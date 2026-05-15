using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RST_Prog3_Vaje_izr
{
    public class Tutorials_02
    {
        public enum Exercises
        {
            Exercise_574 = 1,
            Exercise_575 = 2
        }

        /// <summary>
        /// Postali ste del razvojne ekipe večjega sistema. 
        /// Vaša prva naloga je, da pripravite podrazred NadzornaKomisija razreda Komisija, 
        /// ki bo vseboval funkcijo PreveriClana. 
        /// Funkcija z enakim imenom že obstaja v nadrazredu, 
        /// vendar zaradi politike podjetja, tega razreda trenutno ne morete spreminjati, 
        /// funkcija pa tudi ni označena kot virtual, se pravi, da je ne morete povoziti.
        /// Ali lahko funkcijo z enakim imenom sploh dodate v podrazred? 
        /// Če da, kako in kako se razlikuje njeno obnašanje glede na funkcije, ki jih povozimo z override?
        /// </summary>
        public static void Exercise_574()
        {
            Komisija komisija1 = new Komisija();
            komisija1.PreveriClana();

            NadzornaKomisija nadzornaKomisija = new NadzornaKomisija();
            nadzornaKomisija.PreveriClana(); //Kliče se na INSTANCI!!!

            // Primer, ko kličemo funkcijo z določilom new
            Komisija nadzornaKomisijaCast = (Komisija)nadzornaKomisija;
            nadzornaKomisijaCast.PreveriClana(); //Izpiše se: Preveri člana v razredu Komisija!
                                                 //Če bi imeli override


            Komisija2 komisija2 = new Komisija2();
            komisija2.PreveriClana();

            NadzornaKomisija2 nadzornaKomisija2 = new NadzornaKomisija2();
            nadzornaKomisija2.PreveriClana();

            // Primer, ko kličemo povoženo funkcijo
            Komisija2 nadzornaKomisijaCast2 = (Komisija2)nadzornaKomisija2;
            nadzornaKomisijaCast2.PreveriClana();
        }

        /// <summary>
        /// Definirajte razreda Menu in Jed. 
        /// Menu naj predstavlja dnevni menu v restavraciji (glede na dan), 
        /// ki ima kot lastnost tudi seznam jedi. 
        /// Posamezna jed ima lastnosti naziv in cena.
        /// Za razred Jed naredite podrazred Sladica, ki bo imel dodatno lastnost Kalorije. 
        /// V razredih Jed in Sladica povozite funkcijo ToString, da bo ustrezno vračala vse lastnosti instanc.
        /// Funkcijo ToString povozite tudi v razredu Menu. 
        /// Vrne naj niz z dnevom in vsemi jedmi, ki so na menuju, med seboj pa naj bodo ločene s prazno vrstico. 
        /// V razredu Menu napišite še funkcijo, ki bo izpisala skupno ceno menuja. 
        /// Funkcija naj ima vhodni parameter tipa bool, ki bo določal, 
        /// ali želite ob ceni plačati še 10% napitnine ali ne. 
        /// Če je vrednost parametra true, naj se skupna cena primerno izračuna. 
        /// Za vsaj dva dni v tednu pripravite instanci razreda Menu, 
        /// ki bosta imeli na seznamu jedi vsaj po tri jedi, od tega vsak natanko eno jed tipa Sladica. 
        /// Na koncu oba menuja tudi izpišite.
        /// </summary>
        public static void Exercise_575()
        {
            Menu mojMeni = new Menu();
            mojMeni.Dan = "Ponedeljek";
            mojMeni.SeznamJedi.Add(new Jed { Naziv = "Juha", Cena = 2.50 });

            Jed Burger = new Jed { Naziv = "Smash Burger", Cena = 8 };
            mojMeni.SeznamJedi.Add(Burger);

            mojMeni.SeznamJedi.Add(new Sladica { Naziv = "Čokoladna torta", Cena = 3.50, Kalorije = 450 });

            Console.WriteLine(mojMeni);
            Console.Write($"Cena menija v {mojMeni.Dan} je: {mojMeni.CenaMenija(true):0.00}");
        }
    }

    #region Naloga 5.7.4
    public class Komisija
    {
        public void PreveriClana()
        {
            Console.WriteLine("Preveri člana v razredu Komisija!");
        }
    }

    public class NadzornaKomisija : Komisija
    {
        public new void PreveriClana() // EKSPLICITNO NOVA FUNKCIJA, ISTO IME, KOT ŽE OBSTAJA KJE DRUGJE!!!
        {
            Console.WriteLine("Preveri člana v razredu NadzornaKomisija!");
        }
    }

    public class Komisija2
    {
        public virtual void PreveriClana() // Dopuščamo prepisovanje
        {
            Console.WriteLine("Preveri člana v razredu Komisija2!");
        }
    }

    public class NadzornaKomisija2 : Komisija2
    {
        public override void PreveriClana() // Povozimo funkcijo iz nadrazreda
        {
            Console.WriteLine("Preveri člana v razredu NadzornaKomisija2!");
        }
    }
    #endregion


    #region Naloga 5.7.5
    public class Menu
    {
        public List<Jed> SeznamJedi { get; } = new List<Jed>();
        public string Dan { get; set; }

        public override string ToString()
        {
            string izpis = $"Menu za {Dan}:\n";

            foreach (Jed jed in SeznamJedi)
            {
                izpis += $"- {jed}\n\n";
            }
            return izpis;
        }

        public double CenaMenija(bool dajNapitnino)
        {
            double vsotaMenija = 0;

            foreach (Jed jed in SeznamJedi)
            {
                vsotaMenija += jed.Cena;
            }

            if (dajNapitnino)
            {
                vsotaMenija = vsotaMenija * 1.10;
            }

            return vsotaMenija;
        }
    }

    public class Jed
    {
        public string Naziv { get; set; }
        public double Cena { get; set; }

        public override string ToString()
        {
            return $"Jed: {this.Naziv} ({this.Cena:0.00})";
        }
    }

    public class Sladica : Jed
    {
        public int Kalorije { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Kalorije: {this.Kalorije}";
        }
    }
    #endregion
}
