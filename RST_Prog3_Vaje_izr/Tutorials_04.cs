using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace RST_Prog3_Vaje_izr
{
    public class Tutorials_04
    {
        public enum Exercises
        {
            Exercise_1122 = 1,
            Exercise_1221 = 2,
        }

        /// <summary>
        /// Pripravljamo aplikacijo za lokalni bar, kjer bo izbor koktejlov ponujen kar na tablici, 
        /// na kateri bo gost izbral napitek. Aplikacija bo imela preprost uporabniški vmesnik 
        /// z vsemi napitki v ponudbi, pri čemer ga bomo razvili po navodilih lokalnega umetnika 
        /// z veliko občutka za dizajn in zato uporabniškega vmesnika v nadaljevanju vsaj nekaj 
        /// časa ne bomo spreminjali. Za vse posodobitve ponudbe moramo poskrbeti v zalednem delu aplikacije. 
        /// Ne smemo pozabiti, da bo aplikacijo uporabljal tudi barman, 
        /// ki bo ob naročilu posameznega koktejla zraven dobil še recept za pripravo. 
        /// Pripravite osnutek preproste verzije opisane aplikacije. 
        /// Pri implementaciji ustrezno uporabite vzorec factory.
        /// </summary>
        public static void Exercise_1122()
        {
            Console.WriteLine($"Kateri koktejl želite naročiti?");
            CoctailType type = InterfaceFunctions.ChooseOption<CoctailType>();

            Coctail? coctail = CoctailFactory.CreateCoctail(type);
        }

        /// <summary>
        /// Pripravite razred Pizza, ki naj ima 8 različnih tipov sestavin, 
        /// katerih ne želimo podajati preko konstruktorja.
        /// Zato pripravite ustrezne razrede za uporabo vzorca builder.
        /// </summary>
        public static void Exercise_1221()
        {
            Console.WriteLine($"Katero pizzo smo si zaželeli:");
            PizzaType type = InterfaceFunctions.ChooseOption<PizzaType>();

            PizzaFactory pf = new PizzaFactory();
            Pizza? pizza = pf.CreatePizza(type);
        }
    }


    #region Naloga 10.2.2

    public enum CoctailType
    {
        BloodyMary = 1,
        Hugo = 2,
        Negroni = 3
    }

    public abstract class Coctail
    {
        public abstract double AlcoholVolume { get; }
        public double Price { get; set; }
        public List<string> Ingredients { get; } = new List<string>();

        internal Coctail(double price)
        {
            this.Price = price;
        }
    }

    public class Hugo : Coctail
    {
        public override double AlcoholVolume => 40;

        internal Hugo(double price) : base(price)
        {
            this.Ingredients.AddRange(["Lime", "Prosecco", "Mint"]);
        }
    }

    public class Negroni : Coctail
    {
        public override double AlcoholVolume => 45;

        internal Negroni(double price) : base(price)
        {
            this.Ingredients.AddRange(["Gin", "Vermut", "Campari"]);
        }
    }

    public class CoctailFactory
    {
        public static Coctail? CreateCoctail(CoctailType type)
        {
            Coctail? coctail = null;
            switch (type)
            {
                case CoctailType.Hugo:
                    coctail = new Hugo(30);
                    break;
                case CoctailType.Negroni:
                    coctail = new Negroni(22);
                    break;
            }
            return coctail;
        }
    }

    #endregion


    #region Naloga 11.2.1

    public class Pizza
    {
        internal Pizza() { }

        public bool Cheese { get; set; }
        public bool Mushrooms { get; set; }
        public bool Egg { get; set; }
        public bool Pineapple { get; set; }
        public bool Pepperoni { get; set; }
        public bool BuffaloMozzarella { get; set; }
        public bool Pelatti { get; set; }
        public bool Olives { get; set; }
    }

    public interface IPizzaBuilder
    {
        void AddCheese();
        void AddMushrooms();
        void AddPineapple();
        void AddPepperoni();
        void AddEgg();
        void AddBuffaloMozzarella();
        void AddPelatti();
        void AddOlives();
        Pizza BuildPizza();
    }

    public class PizzaBuilder : IPizzaBuilder
    {
        private Pizza instance = new Pizza();

        public void AddBuffaloMozzarella()
        {
            instance.BuffaloMozzarella = true;
        }

        public void AddCheese()
        {
            instance.Cheese = true;
        }

        public void AddMushrooms()
        {
            instance.Mushrooms = true;
        }

        public void AddOlives()
        {
            instance.Olives = true;
        }

        public void AddPelatti()
        {
            instance.Pelatti = true;
        }

        public void AddPepperoni()
        {
            instance.Pepperoni = true;
        }
        public void AddEgg()
        {
            instance.Egg = true;
        }

        public void AddPineapple()
        {
            instance.Pineapple = true;
        }

        public Pizza BuildPizza()
        {
            return instance;
        }
    }

    public enum PizzaType
    {
        Hawai = 1,
        Farmers = 2,
        Classic = 3
    }

    public class PizzaFactory
    {
        private PizzaBuilder builder = new PizzaBuilder();

        public Pizza? CreatePizza(PizzaType type)
        {
            Pizza? pizza = null;
            switch (type)
            {
                case PizzaType.Hawai:
                    pizza = CreateHawaiPizza();
                    break;
                case PizzaType.Farmers:
                    pizza = CreateFarmersPizza();
                    break;
                case PizzaType.Classic:
                    pizza = CreateClassicPizza();
                    break;
            }

            return pizza;
        }

        private Pizza? CreateHawaiPizza()
        {
            builder.AddCheese();
            builder.AddPineapple();
            builder.AddPelatti();
            return builder.BuildPizza();
        }
        private Pizza? CreateFarmersPizza()
        {
            builder.AddCheese();
            builder.AddPepperoni();
            builder.AddPelatti();
            builder.AddEgg();
            builder.AddOlives();
            return builder.BuildPizza();
        }
        private Pizza? CreateClassicPizza()
        {
            builder.AddCheese();
            builder.AddPepperoni();
            builder.AddPelatti();
            builder.AddOlives();
            return builder.BuildPizza();
        }
    }

    #endregion
}
