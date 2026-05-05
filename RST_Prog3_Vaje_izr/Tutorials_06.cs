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
    }

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
}
