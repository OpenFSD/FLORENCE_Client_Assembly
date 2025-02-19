using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Framework
    {
        static private Client_Assembly.Client client = null;
        static private Client_Assembly.Networking networkingClient;

        static private Int16 threadId = 0;

        public Framework() 
        {
            client = new Client_Assembly.Client();
            while (client == null){ /* Wait whileis created */ }
            client.GetExecute().Initialise();

            //Valve.Sockets.Library.Initialize();
            // networkingClient = new Client_Assembly.Frame.Networking();
            //while (networkingClient == null) { /* wait untill created */ }

            client.GetExecute().Initialise_Threads(Framework.GetClient().GetGlobal().Get_NumCores());

            System.Console.WriteLine("Client_Assembly: Framework");//TEST
        }

        static public Client_Assembly.Client GetClient()
        {
            return client;
        }

        static public Client_Assembly.Networking GetNetworking()
        {
            return networkingClient;
        }
    }
}
