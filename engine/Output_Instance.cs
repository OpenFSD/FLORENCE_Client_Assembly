using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Outputs
{
    public class Output_Instance
    {
        static private FLORENCE.Output empty_OutputBuffer;
        static private FLORENCE.Output[] outputDoubleBuffer;
        static private FLORENCE.Output transmitOutputBuffer;

        public Output_Instance() 
        {
            empty_OutputBuffer = new FLORENCE.Output();
            while (empty_OutputBuffer == null) { /* Wait while is created */ }
            empty_OutputBuffer.InitialiseControl();

            outputDoubleBuffer = new FLORENCE.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                outputDoubleBuffer[index] = empty_OutputBuffer;
                while (outputDoubleBuffer == null) { /* Wait while is created */ }
            }

            transmitOutputBuffer = new FLORENCE.Output();
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

        public FLORENCE.Output GetEmptyOutput()
        {
            return empty_OutputBuffer;
        }
        public FLORENCE.Output GetBuffer_FrontOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(FLORENCE.Framework.GetClient().GetData().GetState_Buffer_Output_ToWrite())];
        }
        public FLORENCE.Output GetBuffer_BackOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(!FLORENCE.Framework.GetClient().GetData().GetState_Buffer_Output_ToWrite())];
        }

        public FLORENCE.Output GetTransmitOutputBuffer()
        {
            return transmitOutputBuffer;
        }


        public void SetBuffer_Output(FLORENCE.Output value)
        {
            outputDoubleBuffer[BoolToInt16(!Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }

        public void SetBuffer_SubSet_OutputAction(FLORENCE.Output value)
        {
            outputDoubleBuffer[BoolToInt16(!Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }
    }
}
