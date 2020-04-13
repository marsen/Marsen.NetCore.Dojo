using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;
using SlackAPI;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class Slack : INotification
    {
        public void Notification(string message)
        {
            var slackClient = new SlackClient("my api token");
            slackClient.PostMessage(messageResponse => { }, "my channel", message, "my bot name");
        }
    }
}