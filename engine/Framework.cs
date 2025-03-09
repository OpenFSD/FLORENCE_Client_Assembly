using Florence.NetworkingClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Framework
    {
        static private Client_Assembly.Client client = null;
        static private Networking networkingClient;

        static private Int16 threadId = 0;

        public Framework() 
        {
            client = new Client_Assembly.Client();
            while (client == null){ /* Wait whileis created */ }
            client.GetExecute().Initialise();
            
            //Florence.NetworkingClient.Networking.CreateNetworkingClient();
            //StringBuilder errorMessage = new StringBuilder(1024);//ToDo
            //Valve.Sockets.NetworkingIdentity indentiy = Florence.NetworkingClient.Networking.Get_Identity();//ToDo
            //Valve.Sockets.Library.Initialize(ref indentiy, errorMessage);//ToDo

            client.GetExecute().Initialise_Threads(Framework.GetClient().GetGlobal().Get_NumCores());

            System.Console.WriteLine("Client_Assembly: Framework");//TEST
        }

        static public Client_Assembly.Client GetClient()
        {
            return client;
        }

        static public Networking GetNetworking()
        {
            return networkingClient;
        }
    }
}
