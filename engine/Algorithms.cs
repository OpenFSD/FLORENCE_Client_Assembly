using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli
{
    public class Algorithms
    {
        static private FLORENCE.Frame.Cli.Algo.IO_ListenRespond io_ListenRespond;
        static private FLORENCE.Frame.Cli.Algo.User_Alg user_Alg;

        public Algorithms(int numberOfCores) 
        {

            System.Console.WriteLine("FLORENCE: Algorithms");//TEST
        }

        public void Initialise(int numberOfCores)
        {
            io_ListenRespond = new FLORENCE.Frame.Cli.Algo.IO_ListenRespond();
            while (io_ListenRespond == null) { /* wait untill class constructed */ }
            io_ListenRespond.InitialiseControl();
        }

       // public FLORENCE.Frame.Cli.Algo.User_Alg GetGameAlgorithms()
       // {
       //     return gameAlgorithms;
       // }

        public FLORENCE.Frame.Cli.Algo.IO_ListenRespond GetIO_ListenRespond()
        {
            return io_ListenRespond;
        }
    }
}
