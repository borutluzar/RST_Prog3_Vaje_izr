using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RST_Prog3_Vaje_izr
{
    public class Tutorials_06
    {
        public enum Exercises
        {
            Exercise_1421 = 1,
            Exercise_823 = 2,
            Exercise_1521 = 3,
            Exercise_1522 = 4
        }

        /// <summary>
        ///
        /// </summary>
        public static void Exercise_1421()
        {
            OrdinaryMessage msg = new OrdinaryMessage();
            Console.WriteLine(msg.Prepare());

            TimeDecorator timeMsg = new TimeDecorator(msg);
            Console.WriteLine(timeMsg.Prepare());

            EncodeDecorator encodeMsg = new EncodeDecorator(msg);
            Console.WriteLine(encodeMsg.Prepare());

            TimeDecorator timeMsg2 = new TimeDecorator(encodeMsg);
            Console.WriteLine(timeMsg2.Prepare());
        }

        /// <summary>
        /// Zapišite razširitveno funkcijo, ki ugotovi, 
        /// če je dani niz palindrom ali ne.
        /// </summary>
        public static void Exercise_823()
        {
            string pal1 = "RibaRežeRaciRep";
            string pal2 = "PericaRežeRaciRep";

            Console.WriteLine($"\"{pal1}\" {(pal1.IsPalindrom() ? "je" : "ni")} palindrom!");
            Console.WriteLine($"\"{pal2}\" {(pal2.IsPalindrom() ? "je" : "ni")} palindrom!");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Exercise_1521()
        {
            ReadableWeatherProxy rwProxy = new ReadableWeatherProxy();
            // Trenutno stanje:
            Console.WriteLine(rwProxy.AirPressure());
            Console.WriteLine(rwProxy.GetTemperature());
            Console.WriteLine(rwProxy.PercipitationLevel());
            Console.WriteLine(rwProxy.WindSpeed());
        }

        public static void Exercise_1522()
        {
            List<IBook> lstBooks = new();
            Random rnd = new Random();
            for(int i = 0;i<100; i++)
            {
                lstBooks.Add(new BookProxy(rnd.Next(300, 1600)));
            }
            Console.WriteLine("Knjige so naložene");

            lstBooks[13].ShowContent();
            lstBooks[63].ShowContent();
        }
    }

    #region Naloga 14.2.1
    public interface IMessage
    {
        string Prepare();
    }

    public class OrdinaryMessage : IMessage
    {
        public string Prepare()
        {
            return "Naše pomembno sporočilo vsem, ki jih ni tukaj!";
        }
    }

    public abstract class MessageDecorator : IMessage
    {
        protected IMessage message;

        protected MessageDecorator(IMessage message)
        {
            this.message = message;
        }

        public abstract string Prepare();
    }

    public class TimeDecorator : MessageDecorator
    {
        public TimeDecorator(IMessage message) : base(message) { }

        public override string Prepare()
        {
            return $"[{DateTime.Now:HH:mm:ss}]\t{message.Prepare()}";
        }
    }

    public class EncodeDecorator : MessageDecorator
    {
        public EncodeDecorator(IMessage message) : base(message) { }

        public override string Prepare()
        {
            var lst = message.Prepare().Reverse().ToList();
            var output = string.Empty;
            lst.ForEach(x => { output += x; });
            return output;
        }
    }
    #endregion

    #region Naloga 8.2.3

    public static class Extensions
    {
        public static bool IsPalindrom(this string word)
        {
            word = word.ToLower();
            var lstReverse = word.Reverse().ToList();

            for (int i = 0; i < lstReverse.Count; i++)
            {
                if (lstReverse[i] != word[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    #endregion

    #region Naloga 15.2.1

    public interface IWeatherData
    {
        string GetTemperature();
        string AirPressure();
        string PercipitationLevel();
        string WindSpeed();
    }

    public class WeatherData : IWeatherData
    {
        public string AirPressure()
        {
            return "" + new Random().Next(700, 1300);
        }

        public string GetTemperature()
        {
            return "" + new Random().NextDouble(-15, 40, decimalPlaces: 1);
        }

        public string PercipitationLevel()
        {
            return "" + new Random().Next(0, 200);
        }

        public string WindSpeed()
        {
            return "" + new Random().NextDouble(0, 4.0);
        }
    }

    public class ReadableWeatherProxy : IWeatherData
    {
        private readonly WeatherData weatherData = new WeatherData();

        public ReadableWeatherProxy() { }

        public string AirPressure()
        {
            return "Zračni tlak: " + int.Parse(weatherData.AirPressure());
        }

        public string GetTemperature()
        {
            return "Temperatura: " + double.Parse(weatherData.GetTemperature());
        }

        public string PercipitationLevel()
        {
            return "Količina padavin: " + int.Parse(weatherData.PercipitationLevel());
        }

        public string WindSpeed()
        {
            return "Hitrost vetra: " + double.Parse(weatherData.WindSpeed());
        }
    }

    public static class RandomExtensions
    {
        public static double NextDouble(this Random rnd, double lowerBound, double upperBound, int decimalPlaces = 2)
        {
            // -12,21 - 23,45?
            int factor = (int)Math.Pow(10, decimalPlaces);
            int result = rnd.Next((int)(lowerBound * factor), (int)(upperBound * factor));
            return (double)result / factor;
        }
    }

    #endregion

    #region Naloga 15.2.2

    public interface IBook
    {
        void ShowContent();
    }

    public class RealBook : IBook
    {
        public int Pages { get; }

        public RealBook(int pgs)
        {
            this.Pages = pgs;
            ShowContent();
        }

        public void ShowContent()
        {
            Console.WriteLine("Odprli smo knjigo in beremo!");
            Thread.Sleep(this.Pages);            
        }
    }

    public class BookProxy : IBook 
    {
        private RealBook book;
        private int pages;

        public BookProxy(int pgs)
        {
            this.pages = pgs;
        }

        public void ShowContent()
        {
            if(book == null)
            {
                book = new RealBook(this.pages);
            }
            Console.WriteLine("Prebrano!");
        }
    }
    #endregion
}
