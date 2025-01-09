using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Algo
{
    public class Concurrent
    {
        static private FLORENCE.Frame.Cli.Algo.Conc.Concurrent_Control concurrent_Control;
        public Concurrent() 
        {
            concurrent_Control = null;
        } 

        public void InitialiseControl()
        {
            concurrent_Control = new FLORENCE.Frame.Cli.Algo.Conc.Concurrent_Control();
            while (concurrent_Control == null) { /* Wait while is created */ }
        }

        public void Thread_Concurrent()
        {
            while (true)
            {

            }
        }
    }
}
