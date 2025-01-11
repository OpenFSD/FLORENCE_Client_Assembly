
namespace FLORENCE.Inputs
{
    public class Input_Instance
    {
        static private FLORENCE.Inputs.Input_Instance_Control inputInstance_Control;
        static private FLORENCE.Input empty_InputBuffer;
        static private FLORENCE.Input[] inputDoubleBuffer;
        static private FLORENCE.Input transmitInputBuffer;

        public Input_Instance() 
        {
            inputInstance_Control = new FLORENCE.Inputs.Input_Instance_Control();
            while (inputInstance_Control == null) { /* Wait while is created */ }

            empty_InputBuffer = new FLORENCE.Input();
            while (empty_InputBuffer == null) { /* Wait while is created */ }
            empty_InputBuffer.InitialiseControl();

            inputDoubleBuffer = new FLORENCE.Input[2];
            for (byte index = 0; index < 2; index++)
            {
                inputDoubleBuffer[index] = empty_InputBuffer;
                while (inputDoubleBuffer[index] == null) { /* Wait while is created */ }
            }

            transmitInputBuffer = new FLORENCE.Input();
            while (transmitInputBuffer == null) { /* Wait while is created */ }
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

        public FLORENCE.Input GetBuffer_FrontInputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(FLORENCE.Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())];
        }
        public FLORENCE.Input GetBuffer_BackInputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(!FLORENCE.Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())];
        }

        public FLORENCE.Input GetEmptyInput()
        {
            return empty_InputBuffer;
        }

        public FLORENCE.Inputs.Input_Instance_Control GetInputInstance_Control()
        {
            return inputInstance_Control;
        }

        public FLORENCE.Input GetTransmitInputBuffer()
        {
            return transmitInputBuffer;
        }

        public void SetBuffer_Input(FLORENCE.Input value)
        {
            inputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }
        public void SetBuffer_SubSet_InputActionInStream(FLORENCE.Input value)
        {
            inputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }
    }
}
