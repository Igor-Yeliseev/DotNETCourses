using NetworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Igor Eliseev", "127.0.0.1");

            ClientSocket clientSocket = new ClientSocket(client, "127.0.0.1", 8080);
            
            Message message = new Message("Hello! It's my first message.", client);
            
            while(true)
            {
                clientSocket.Connect();
                Console.Write("Enter text: ");
                string msgText = Console.ReadLine();
                message.Text = msgText;
                clientSocket.Send(message);
                Console.Write("Ответ от сервера: ");
                string answer = clientSocket.Receive();
                Console.WriteLine(answer);

                clientSocket.Close();
            }
        }
    }
}
