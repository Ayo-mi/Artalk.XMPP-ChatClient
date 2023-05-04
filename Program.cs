using Artalk.Xmpp.Client;
using Artalk.Xmpp.Im;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XMPPChatClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                ArtalkXmppClient c = new ArtalkXmppClient("localhost", "ay", "123456", 5222);

                c.Connect("PC");
                Console.WriteLine(c.Connected);
                c.Message += OnIncomingMessage;
                //Thread.Sleep(15000);
                //c.Close();
                //Console.WriteLine("Disconnected");
                Console.ReadKey();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        static bool SendMessage(ArtalkXmppClient client, string jid, string message)
        {
            try
            {
                client.SendMessage(jid, message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        static void OnIncomingMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Message from <" + e.Jid + ">:\n" + e.Message.Body);

        }
    }
}
