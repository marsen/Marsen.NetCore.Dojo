using System;
using System.Net;
using System.Text;
using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Classes.GOOS;

public static class GreetingServer
{
    private static HttpListener _httpListener;

    public static void main(params string[] args)
    {
        _httpListener = new HttpListener();
        _httpListener.Prefixes.Add(SampleUri);
        _httpListener.Start();
        _httpListener.BeginGetContext(GetContext, _httpListener);
    }

    private static string SampleUri => "http://+:8080/";

    private static void GetContext(IAsyncResult ar)
    {
        if (ar.AsyncState is HttpListener httpListener)
        {
            var context = httpListener.EndGetContext(ar); //接收到的請求context（一個環境封裝體）
            context.Response.ContentType = "html";
            context.Response.ContentEncoding = Encoding.UTF8;
            using var output = context.Response.OutputStream;
            var hourOfDay = SystemDateTime.Now.Hour.ToString();
            var response = new Greeter().Invoke(context.Request.QueryString["Name"], hourOfDay);
            output.Write(Encoding.UTF8.GetBytes(response), 0, Encoding.UTF8.GetBytes(response).Length);
        }
    }

    public static void stop()
    {
        _httpListener.Stop();
    }
}