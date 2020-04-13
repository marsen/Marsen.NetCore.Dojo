using SlackAPI;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class Slack
    {
        public void Notification(string accountId)
        {
            //// notify
            string message = $"account:{accountId} try to login failed";
            var slackClient = new SlackClient("my api token");
            slackClient.PostMessage(messageResponse => { }, "my channel", message, "my bot name");
        }
    }
}