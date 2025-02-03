using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{ 
    public class IO_ListenRespond
    {
        static private Int16 threadId = 1;
        static private Client_Assembly.IO_ListenRespond_Control io_Control;

        public IO_ListenRespond() 
        {
            io_Control = null;
        }
        public void InitialiseControl()
        {
            io_Control = new Client_Assembly.IO_ListenRespond_Control();
            while (io_Control == null) { /* Wait while is created */ }
        }

        public void Thread_io_ListenRespond()
        {
            Framework.GetClient().GetExecute().GetExecute_Control().SetConditionCodeOfThisThreadedCore(threadId);
            while (Framework.GetClient().GetExecute().GetExecute_Control().GetFlag_SystemInitialised((short)Framework.GetClient().GetGlobal().Get_NumCores()) != false)
            {
                // wait untill ALL threads initalised in preperation of system init.
            }
            while (Framework.GetClient().GetExecute().GetExecute_Control().GetFlag_SystemInitialised((short)Framework.GetClient().GetGlobal().Get_NumCores()) == false)
            {
                switch (Framework.GetClient().GetAlgorithms().GetIO_ListenRespond().GetIO_Control().GetFlag_IO_ThreadState())
                {
                    case true:
                        Client_Assembly.Networking.CreateAndSendNewMessage(
                                (UInt16)Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().GetPraiseEventId()
                        );
                        break;
                        
                    case false:
                        Networking.CopyPayloadFromMessage();
                        break;
                }
            }
        }
        public Client_Assembly.IO_ListenRespond_Control GetIO_Control()
        {
            return io_Control;
        }
    }
}
