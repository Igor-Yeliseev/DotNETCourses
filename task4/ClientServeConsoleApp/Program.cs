using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetworkLibrary;

namespace ClientServeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerSocket server = new ServerSocket(8080, 6);
            server.Сreate();

            Action Run = delegate
            {
                bool running = true;

                while(running)
                {
                    server.WaitClientConnection();
                    Thread.Sleep(5);
                }
            };

            Thread thr_Server = new Thread(new ThreadStart(Run));
            thr_Server.Start();
        }
    }
}
