// main.sc
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Create an HttpListener instance and configure it to listen on port 8002
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://*:8002/");
        listener.Start();
        Console.WriteLine("Listening on port 8002...");

        while (true)
        {
            // Await a request and process it
            HttpListenerContext context = await listener.GetContextAsync();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            // Example response text
            string responseString = "<html><body><h1>Welcome to srv02!</h1></body></html>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            // Write the response to the output stream
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }
}
