// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text;
using System.Threading;
using Quartz;

StreamWriter OurStream;
OurStream = File.CreateText(@"C:\Users\LauraGiuffre\Documents\Log\log.txt");
OurStream.WriteLine("This text is for task scheduler demo test file created on " + DateTime.Now);
OurStream.Close();
Console.WriteLine("File Created successfully!");

HttpListener _httpListener = new HttpListener();

Console.WriteLine("Starting server...");
_httpListener.Prefixes.Add("http://localhost:5000/");
_httpListener.Start();
Console.WriteLine("Server started.");
Thread _responseThread = new Thread(ResponseThread);
_responseThread.Start();

void ResponseThread()
{
    while (true)
    {
        HttpListenerContext context = _httpListener.GetContext(); // get a context
                                                                  // Now, you'll find the request URL in context.Request.Url
        byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 5000</title></head>" +
        "<body>Welcome to the <strong>Localhost server</strong> -- <em>port 5000!</em></body></html>"); // get the bytes to response
        context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); // write bytes to the output stream
        context.Response.KeepAlive = false; // set the KeepAlive bool to false
        context.Response.Close(); // close the connection
        Console.WriteLine("Respone given to a request.");
    }
}
