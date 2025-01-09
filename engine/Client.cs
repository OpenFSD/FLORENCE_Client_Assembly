using FLORENCE;
using FLORENCE.Frame.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Valve.Sockets;

namespace FLORENCE.Frame
{
    public class Client
    {
        static private FLORENCE.Frame.Cli.Algorithms algorithms;
        static private FLORENCE.Frame.Cli.Data data;
        static private FLORENCE.Frame.Cli.Execute execute;
        static private FLORENCE.Frame.Cli.Global global;

        public Client() 
        {
            global = new FLORENCE.Frame.Cli.Global();
            while (global == null) { /* Wait while is created */ }

            algorithms = new FLORENCE.Frame.Cli.Algorithms(global.Get_NumCores());
            while (algorithms == null) { /* Wait while is created */ }

            data = new FLORENCE.Frame.Cli.Data();
            while (data == null) { /* Wait while is created */ }
            data.InitialiseControl();

            execute = new FLORENCE.Frame.Cli.Execute(global.Get_NumCores());
            while (execute == null) { /* Wait while is created */ }
            execute.Initialise_Control(global.Get_NumCores(), global);

            System.Console.WriteLine("FLORENCE: Client");
        }

        public FLORENCE.Frame.Cli.Algorithms GetAlgorithms()
        {
            return algorithms;
        }
        public FLORENCE.Frame.Cli.Data GetData()
        {
            return data;
        }

        public FLORENCE.Frame.Cli.Global GetGlobal()
        {
            return global;
        }

        public FLORENCE.Frame.Cli.Execute GetExecute()
        {
            return execute;
        }
    }
}