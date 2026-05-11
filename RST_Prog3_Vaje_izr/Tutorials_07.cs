using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RST_Prog3_Vaje_izr
{
    public class Tutorials_07
    {
        public enum Exercises
        {
            Exercise_1631 = 1,
            Exercise_1631_events = 2,
            Exercise_1722 = 3,
        }

        /// <summary>
        ///
        /// </summary>
        public static void Exercise_1631()
        {
            NewsPortal sta = new NewsPortal();

            TvShow rtv = new TvShow("RTV");
            TvShow pop = new TvShow("POP TV");

            sta.Subscribe(rtv, NewsType.Politics);
            sta.Subscribe(rtv, NewsType.Sports);

            sta.Subscribe(pop, NewsType.Fun);
            sta.Subscribe(pop, NewsType.Sports);
            sta.Subscribe(pop, NewsType.LocalNews);

            sta.RetrieveNews("Dončič še kar počiva!", NewsType.Sports);
            sta.RetrieveNews("Maraton bo v Novem mestu!", NewsType.LocalNews);
        }

        public static void Exercise_1631_event()
        {
            PressAgency sta = new PressAgency();

            Newspaper delo = new Newspaper("Delo");

            sta.OnFunNewsRetrieved += delo.PrintNews;
            sta.OnPoliticsNewsRetrieved += delo.PrintNews;

            sta.RetrieveNews("Dončič še kar počiva!", NewsType.Fun);
            sta.RetrieveNews("Maraton bo v Novem mestu!", NewsType.LocalNews);
        }

        public static void Exercise_1722()
        {
            ShippingCalculator calc = new ShippingCalculator();
            SloveniaPostStrategy sloPost = new SloveniaPostStrategy();
            DhlExpressStrategy dhl = new DhlExpressStrategy();

            // Nastavimo strategijo
            calc.DeliveryMethod(sloPost);
            calc.DeliveryMethod(dhl);

            // Izračunamo ceno
            calc.GetFinalPrice(1.6);
        }
    }

    #region Naloga 16.3.1
    public interface INewsObserver
    {
        void Update(string news);
    }

    public interface INewsSubject
    {
        void Subscribe(INewsObserver newsObserver, NewsType newsType);
        void Unsubscribe(INewsObserver newsObserver, NewsType newsType);
        void NotifyAll(string news, NewsType type);
    }

    public enum NewsType
    {
        Sports = 1,
        Politics = 2,
        Fun = 3,
        LocalNews = 4
    }

    public class NewsPortal : INewsSubject
    {
        private Dictionary<NewsType, List<INewsObserver>> dicObservers = new();

        public NewsPortal()
        {
            foreach (var section in Enum.GetValues(typeof(NewsType)))
            {
                dicObservers.Add((NewsType)section, new List<INewsObserver>());
            }
        }

        public void RetrieveNews(string news, NewsType type)
        {
            NotifyAll(news, type);
        }

        public void NotifyAll(string news, NewsType type)
        {
            foreach(var observer in dicObservers[type])
            {
                observer.Update(news);
            }
        }

        public void Subscribe(INewsObserver newsObserver, NewsType newsType)
        {
            this.dicObservers[newsType].Add(newsObserver);
        }

        public void Unsubscribe(INewsObserver newsObserver, NewsType newsType)
        {
            this.dicObservers[newsType].Remove(newsObserver);
        }
    }

    public class TvShow : INewsObserver
    {
        private string tvShowName;

        public TvShow(string name)
        {
            this.tvShowName = name;
        }

        public void Update(string news)
        {
            Console.WriteLine($"Dragi gledalci {this.tvShowName}, tole je zadnja novica:" +
                $"\n {news}");
        }
    }
    #endregion

    #region Naloga 16.3.1 z eventi

    public interface INewsEvents
    {
        event Action<string> OnSportsNewsRetrieved;
        event Action<string> OnPoliticsNewsRetrieved;
        event Action<string> OnFunNewsRetrieved;
        event Action<string> OnLocalNewsRetrieved;
    }

    public class PressAgency : INewsEvents
    {
        public event Action<string>? OnSportsNewsRetrieved;
        public event Action<string>? OnPoliticsNewsRetrieved;
        public event Action<string>? OnFunNewsRetrieved;
        public event Action<string>? OnLocalNewsRetrieved;

        public void RetrieveNews(string news, NewsType type)
        {
            switch(type)
            {
                case NewsType.Sports:
                    this.OnSportsNewsRetrieved?.Invoke(news);
                    break;
                case NewsType.Fun:
                    this.OnFunNewsRetrieved?.Invoke(news);
                    break;
                case NewsType.Politics:
                    this.OnPoliticsNewsRetrieved?.Invoke(news);
                    break;
                case NewsType.LocalNews:
                    this.OnLocalNewsRetrieved?.Invoke(news);
                    break;
            }            
        }
    }

    public class Newspaper
    {
        private string Name { get; }
        public Newspaper(string name)
        {
            this.Name = name;
        }

        public void PrintNews(string news)
        {
            Console.WriteLine($"[{this.Name}] Novica je naslednja: " +
                $"\n{news}");
        }
    }

    #endregion


    #region Naloga 17.2.2

    public interface IShippingStrategy
    {
        double ComputeDeliveryRate(double weight);
    }

    public class SloveniaPostStrategy : IShippingStrategy
    {
        public double ComputeDeliveryRate(double weight)
        {
            return 2.0 + 0.15 * weight;
        }
    }

    public class DhlExpressStrategy : IShippingStrategy
    {
        public double ComputeDeliveryRate(double weight)
        {
            return 3.0 + 0.12 * weight;
        }
    }

    public class LocalPickupStrategy : IShippingStrategy
    {
        public double ComputeDeliveryRate(double weight)
        {
            return 0.0;
        }
    }


    public class ShippingCalculator
    {
        private IShippingStrategy ShippingStrategy { get; set; }

        public void DeliveryMethod(IShippingStrategy s)
        {
            this.ShippingStrategy = s;
        }

        public void GetFinalPrice(double weight)
        {
            Console.WriteLine($"Cena vaše dostave je: {this.ShippingStrategy.ComputeDeliveryRate(weight)} eur");
        }
    }

    #endregion
}
