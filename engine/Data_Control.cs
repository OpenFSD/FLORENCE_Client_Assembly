using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Data_Control
    {
        static private bool flag_TransmitInputStackLoaded;
        static private bool flag_OutputStackLoaded;

        public Data_Control() 
        { 
        
        }

        public void Pop_Stack_InputActions(
            Client_Assembly.Inputs.Input reference,
            List<Client_Assembly.Inputs.Input> inputStack
        )
        {
            reference = inputStack[1];
            inputStack.RemoveAt(1);
        }

        public void Pop_Stack_OutputRecieve()
        {

        }

        public void Push_Stack_InputActions(
            List<Client_Assembly.Inputs.Input> inputStack,
            Client_Assembly.Inputs.Input praiseBuffer
        )
        {
            inputStack.Add(praiseBuffer);
        }

        public void Push_Stack_OutputRecieve(
            List<Client_Assembly.Outputs.Output> outputStack,
            Client_Assembly.Outputs.Output praiseBuffer
        )
        {
            
        }

        public bool GetFlag_IsInputStackLoaded()
        {
            return flag_TransmitInputStackLoaded;
        }

        public bool GetFlag_OutputStackLoaded()
        {
            return flag_OutputStackLoaded;
        }

        public void SetFlag_InputStackLoaded(bool value)
        {
            flag_TransmitInputStackLoaded = value;
        }
        public void SetFlag_OutputStackLoaded(bool value)
        {
            flag_OutputStackLoaded = value;
        }
    }
}
