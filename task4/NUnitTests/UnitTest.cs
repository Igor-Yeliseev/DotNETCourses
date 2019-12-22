using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetworkLibrary;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    class UnitTest
    {
        /// <summary>
        /// Test client and server socket classes
        /// </summary>
        [Test]
        public void TestSocketsFunctions()
        {
            string expectedAnswer = null;
            string actualAnswer = null;
            bool wait = true;

            ServerSocket server = new ServerSocket(8080, 6);

            void ServerRun()
            {
                try
                {
                    server.WaitClientConnection();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Message msg = server.Receive();
                wait = false;
                server.Send(msg);
                
            }
            
            Thread threadServer = new Thread(new ThreadStart(ServerRun));
            threadServer.Start();

            Client client = new Client("Igor Eliseev", null);
            ClientSocket clientSocket = new ClientSocket(client, "127.0.0.1", 8080);
            clientSocket.Connect();
            Message message = new Message("Hello World!", client);

            expectedAnswer = message.ToString();
            clientSocket.Send(message);

            while (wait) ;

            actualAnswer = clientSocket.Receive();
            clientSocket.Close();

            Thread.Sleep(1000);

            Assert.NotNull(expectedAnswer);
            Assert.NotNull(actualAnswer);
            Assert.AreEqual(expectedAnswer, actualAnswer);

            threadServer.Abort();
        }

        /// <summary>
        /// Test translit function in event handler
        /// </summary>
        /// <param name="before"> Message before</param>
        /// <param name="after"> Message after</param>
        [TestCase("Вова Пупкин", "Vova Pupkin")]
        [TestCase("Пришла весна", "Prishla vesna")]
        public void TestTranslit(string before, string after)
        {
            string expectedAnswer = "Name: Igor Eliseev, Message: " + after;
            string actualAnswer = null;
            bool wait = true;

            ServerSocket server = new ServerSocket(8080, 6);

            void ServerRun()
            {
                try
                {
                    server.WaitClientConnection();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Message msg = server.Receive();
                wait = false;
                server.Send(msg);

            }

            Thread threadServer = new Thread(new ThreadStart(ServerRun));
            //Thread threadClient = new Thread(new ThreadStart(ClientRun));
            threadServer.Start();

            Client client = new Client("Igor Eliseev", null);
            ClientSocket clientSocket = new ClientSocket(client, "127.0.0.1", 8080);
            clientSocket.Connect();
            Message message = new Message(before, client);

            clientSocket.Send(message);
            while (wait) ;

            actualAnswer = clientSocket.Receive();
            clientSocket.Close();

            Thread.Sleep(1000);

            Assert.NotNull(expectedAnswer);
            Assert.NotNull(actualAnswer);
            Assert.AreEqual(expectedAnswer, actualAnswer);

            threadServer.Abort();
        }
    }
}
