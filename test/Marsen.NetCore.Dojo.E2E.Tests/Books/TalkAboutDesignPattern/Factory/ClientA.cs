using System;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientA
    {
        public static void Run()
        {
            EmailNotify notify = new EmailNotify {Detail = "Email Detail"};
            notify.Send("warning client A");
        }
    }

    public static class ClientB
    {
        public static void Run()
        {
            SNSNotify notify = new SNSNotify {Information = "SNS Information"};
            notify.Send("warning client B");
        }
    }

    public static class ClientC
    {
        public static void Run()
        {
            VoiceCallNotify notify = new VoiceCallNotify {Conditional = "Voice Conditional"};
            notify.Send("warning client C");
        }
    }

    public class VoiceCallNotify
    {
        public void Send(string msg)
        {
            Console.WriteLine($"VoiceCall {msg}");
        }

        public string Conditional { get; init; }
    }

    public class SNSNotify
    {
        public void Send(string msg)
        {
            Console.WriteLine($"SNS {msg}");
        }

        public string Information { get; init; }
    }

    public class EmailNotify
    {
        public void Send(string msg)
        {
            Console.WriteLine($"Email {msg}");
        }

        public string Detail { get; init; }
    }
}