using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Algorithms
    {
        static private Client_Assembly.IO_ListenRespond io_ListenRespond;
        static private Client_Assembly.Praise_Files.User_Alg user_Alg;

        public Algorithms(int numberOfCores) 
        {

            System.Console.WriteLine("Client_Assembly: Algorithms");//TEST
        }

        public void Initialise(int numberOfCores)
        {
            io_ListenRespond = new Client_Assembly.IO_ListenRespond();
            while (io_ListenRespond == null) { /* wait untill class constructed */ }
            io_ListenRespond.InitialiseControl();
        }

       // public Client_Assembly.Frame.Cli.Algo.User_Alg GetGameAlgorithms()
       // {
       //     return gameAlgorithms;
       // }

        public Client_Assembly.IO_ListenRespond GetIO_ListenRespond()
        {
            return io_ListenRespond;
        }
    }
}
