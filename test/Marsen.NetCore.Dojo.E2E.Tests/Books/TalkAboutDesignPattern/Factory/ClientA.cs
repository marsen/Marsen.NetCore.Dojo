using System;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientA
    {
        public static void Run()
        {
            ///INotification notify = new Email {Detail = "Email Detail"};
            INotification notify = (new SimpleFactory()).Create();
            notify.Send("warning client A");
        }
    }

    public class SimpleFactory
    {
        public INotification Create()
        {
            return new Email {Detail = "Email Detail"};
        }
    }


    public static class ClientB
    {
        public static void Run()
        {
            INotification notify = new SNSNotify {Information = "SNS Information"};
            notify.Send("warning client B");
        }
    }

    public static class ClientC
    {
        public static void Run()
        {
            INotification notify = new VoiceCallNotify {Conditional = "Voice Conditional"};
            notify.Send("warning client C");
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