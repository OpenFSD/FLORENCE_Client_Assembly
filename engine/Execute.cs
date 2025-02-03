using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Client_Assembly
{
    public class Execute
    {
        static private Client_Assembly.Execute_Control execute_Control;
        static private Thread[] concurrent = null;
        static private Thread listenRespond = null;
        static private Thread[] threads = null;
        
        public Execute(int numberOfCores) 
        {
            execute_Control = null;
            threads = new Thread[numberOfCores];//NUMBER OF CORES
            concurrent = new Thread[numberOfCores-2];//NUMBER OF CORES
            Florence.WriteEnable.Stack_Client_OutputRecieve.Create_WriteEnable();
            Florence.Concurrency.ConcurrentQue_Client.Create_ConcurrentQue();
        }

        public void Initialise_Control(
            int numberOfCores,
            Global global
        )
        {
            execute_Control = new Client_Assembly.Execute_Control(numberOfCores);
            while (execute_Control == null) { /* Wait while is created */ }
        }

        public void Initialise()
        {
            Framework.GetClient().GetAlgorithms().Initialise(Framework.GetClient().GetGlobal().Get_NumCores());

        }

        public void Initialise_Threads(
            int numberOfCores
        )
        {
            threads = new Thread[numberOfCores];
            threads[0] = System.Threading.Thread.CurrentThread;
            Framework.GetClient().GetExecute().GetExecute_Control().SetConditionCodeOfThisThreadedCore(0);

            threads[1] = new Thread(Framework.GetClient().GetAlgorithms().GetIO_ListenRespond().Thread_io_ListenRespond);
            threads[1].Start();
        }

        public void Create_And_Run_Graphics()
        {
            using (var graphics = new Client_Assembly.game_Instance.gFX.Graphics(
                Client_Assembly.Framework.GetClient().GetData().GetGame_Instance().GetSettings().GetGameWindowSettings(),
                Client_Assembly.Framework.GetClient().GetData().GetGame_Instance().GetSettings().GetNativeWindowSettings()
            ))
            {
                graphics.Run();
            }
        }

        public Client_Assembly.Execute_Control GetExecute_Control()
        {
            return execute_Control;
        }

        public Thread GetThread(int index)
        {
            return threads[index];
        }
    }   
}
