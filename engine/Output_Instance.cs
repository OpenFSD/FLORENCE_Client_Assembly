using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.Outputs
{
    public class Output_Instance
    {
        static private Client_Assembly.Outputs.Output empty_OutputBuffer;
        static private Client_Assembly.Outputs.Output[] outputDoubleBuffer;
        static private Client_Assembly.Outputs.Output transmitOutputBuffer;

        public Output_Instance() 
        {
            empty_OutputBuffer = new Client_Assembly.Outputs.Output();
            while (empty_OutputBuffer == null) { /* Wait while is created */ }
            empty_OutputBuffer.InitialiseControl();

            outputDoubleBuffer = new Client_Assembly.Outputs.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                outputDoubleBuffer[index] = empty_OutputBuffer;
                while (outputDoubleBuffer == null) { /* Wait while is created */ }
            }

            transmitOutputBuffer = new Client_Assembly.Outputs.Output();
            while (transmitOutputBuffer == null) { /* Wait while is created */ }

        }

        private UInt16 BoolToInt16(bool value)
        {
            UInt16 temp = new UInt16();
            if (value)
            {
                temp = (UInt16)1;
            }
            else if (!value)
            {
                temp = (UInt16)0;
            }
            return temp;
        }

        public Client_Assembly.Outputs.Output GetEmptyOutput()
        {
            return empty_OutputBuffer;
        }
        public Client_Assembly.Outputs.Output GetBuffer_FrontOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(Client_Assembly.Framework.GetClient().GetData().GetState_Buffer_OutputPraise_SideToWrite())];
        }
        public Client_Assembly.Outputs.Output GetBuffer_BackOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(!Client_Assembly.Framework.GetClient().GetData().GetState_Buffer_OutputPraise_SideToWrite())];
        }

        public Client_Assembly.Outputs.Output GetTransmitOutputBuffer()
        {
            return transmitOutputBuffer;
        }


        public void SetBuffer_Output(Client_Assembly.Outputs.Output value)
        {
            outputDoubleBuffer[BoolToInt16(!Framework.GetClient().GetData().GetState_Buffer_OutputPraise_SideToWrite())] = value;
        }
    }
}
