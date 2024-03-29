﻿using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using SlackAPI;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI;

public class Slack : INotification
{
    public void Send(string message)
    {
        var slackClient = new SlackClient("my api token");
        slackClient.PostMessage(_ => { }, "my channel", message, "my bot name");
    }
}