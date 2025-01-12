using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Valve.Sockets;

namespace Client_Assembly
{
    public class Client
    {
        static private Client_Assembly.Algorithms algorithms;
        static private Client_Assembly.Data data;
        static private Client_Assembly.Execute execute;
        static private Client_Assembly.Global global;

        public Client() 
        {
            global = new Client_Assembly.Global();
            while (global == null) { /* Wait while is created */ }

            algorithms = new Client_Assembly.Algorithms(global.Get_NumCores());
            while (algorithms == null) { /* Wait while is created */ }

            data = new Client_Assembly.Data();
            while (data == null) { /* Wait while is created */ }
            data.InitialiseControl();

            execute = new Client_Assembly.Execute(global.Get_NumCores());
            while (execute == null) { /* Wait while is created */ }
            execute.Initialise_Control(global.Get_NumCores(), global);

            System.Console.WriteLine("Client_Assembly: Client");
        }

        public Client_Assembly.Algorithms GetAlgorithms()
        {
            return algorithms;
        }
        public Client_Assembly.Data GetData()
        {
            return data;
        }

        public Client_Assembly.Global GetGlobal()
        {
            return global;
        }

        public Client_Assembly.Execute GetExecute()
        {
            return execute;
        }
    }
}