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
            Exercise_823 = 2
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



    #endregion
}
