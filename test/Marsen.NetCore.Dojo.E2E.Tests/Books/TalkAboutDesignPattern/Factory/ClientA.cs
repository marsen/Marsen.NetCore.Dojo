using System;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientA
    {
        public static void Run()
        {
            var notify = new SimpleFactory().Create("Email");
            notify.Send("warning client A");
        }
    }

    public static class ClientB
    {
        public static void Run()
        {
            var notify = new SimpleFactory().Create("SNS");
            notify.Send("warning client B");
        }
    }

    public static class ClientC
    {
        public static void Run()
        {
            var notify = new SimpleFactory().Create("VoiceCall");
            notify.Send("warning client C");
        }
    }

    public class SimpleFactory
    {
        public INotification Create(string type)
        {
            return type switch
            {
                "Email" => new Email {Detail = "Email Detail"},
                "SNS" => new SNSNotify {Information = "SNS Information"},
                "VoiceCall" => new VoiceCallNotify {Conditional = "Voice Conditional"},
                _ => throw new NotImplementedException()
            };
        }
    }

    public class VoiceCallNotify : INotification
    {
        public void Send(string msg)
        {
            Console.WriteLine($"VoiceCall {msg}");
        }

        public string Conditional { get; init; }
    }

    public class SNSNotify : INotification
    {
        public void Send(string msg)
        {
            Console.WriteLine($"SNS {msg}");
        }

        public string Information { get; init; }
    }

    public class Email : INotification
    {
        public void Send(string msg)
        {
            Console.WriteLine($"Email {msg}");
        }

        public string Detail { get; init; }
    }

    public interface INotification
    {
        void Send(string msg);
    }
}