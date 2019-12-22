using NetworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerSocket server = new ServerSocket(8080, 6);

            bool running = true;

            while (running)
            {
                Console.WriteLine("Ожидаем соединение через порт 8080...");
                try
                {
                    server.WaitClientConnection();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Message msg = server.Receive();
                Console.WriteLine("Данные получены от пользователя " + msg.client.Name);
                server.Send(msg);
                Console.WriteLine("Ответ пользователю " + msg.client.Name + "\n");
            }

            //Action Run = delegate
            //{
                
            //};

            //Thread thr_Server = new Thread(new ThreadStart(Run));
            //thr_Server.Start();
        }
    }
}
