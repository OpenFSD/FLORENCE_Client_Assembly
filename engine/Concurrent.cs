using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Concurrent
    {
        static private Client_Assembly.Concurrent_Control concurrent_Control;
        public Concurrent() 
        {
            concurrent_Control = null;
        } 

        public void InitialiseControl()
        {
            concurrent_Control = new Client_Assembly.Concurrent_Control();
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
