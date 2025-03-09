using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Algorithms
    {
        static private Client_Assembly.Concurrent[] concurrent;
        static private Client_Assembly.IO_Listen_Respond io_ListenRespond;
        static private Client_Assembly.Praise_Files.User_Alg user_Alg;

        public Algorithms(int numberOfCores) 
        {

            System.Console.WriteLine("Client_Assembly: Algorithms");//TEST
        }

        public void Initialise(int numberOfCores)
        {
            io_ListenRespond = new Client_Assembly.IO_Listen_Respond();
            while (io_ListenRespond == null) { /* wait untill class constructed */ }
            io_ListenRespond.InitialiseControl();

            concurrent = new Client_Assembly.Concurrent[2];//Number Of Cores - 2
            for (byte i = 0; i < (Client_Assembly.Framework.GetClient().GetGlobal().Get_NumCores() - 2); i++)
            {
                concurrent[i] = new Client_Assembly.Concurrent();
                while (concurrent[i] == null) { /* wait untill class constructed */ }
                concurrent[i].InitialiseControl();
            }
        }

        public Client_Assembly.Concurrent GetConcurrent(byte index)
        {
            return concurrent[index];
        }

        public Client_Assembly.IO_Listen_Respond GetIO_ListenRespond()
        {
            return io_ListenRespond;
        }
    }
}
