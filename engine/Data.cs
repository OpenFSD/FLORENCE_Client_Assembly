using FLORENCE.Frame.Cli.Dat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli
{
    public class Data
    {
        static private FLORENCE.Frame.Cli.Dat.Arena arena;
        static private FLORENCE.Frame.Cli.Dat.Data_Control data_Control;
        static private FLORENCE.Frame.Cli.Dat.Input empty_InputBuffer;
        static private FLORENCE.Frame.Cli.Dat.Output empty_OutputBuffer;
        static private FLORENCE.Frame.Cli.Dat.Input[] inputDoubleBuffer;
        static private FLORENCE.Frame.Cli.Dat.Output[] outputDoubleBuffer;
        static private FLORENCE.Frame.Cli.Dat.Settings settings;
        static private List<FLORENCE.Frame.Cli.Dat.Input> stack_InputActions;
        static private List<FLORENCE.Frame.Cli.Dat.Output> stack_OutputRecieves;
        static private FLORENCE.Frame.Cli.Dat.Input[] tramsnitInputDoubleBuffer;
        static private FLORENCE.Frame.Cli.Dat.Output[] recieveOutputDoubleBuffer;
        static private FLORENCE.Frame.Cli.Dat.User_I user_IO;
        static private FLORENCE.Frame.Cli.Dat.Map_Default mapDefault;

        static private bool state_Buffer_Input_ToWrite;
        static private bool state_Buffer_Output_ToWrite;
        static private bool state_Buffer_TransmitInput_ToWrite;
        static private bool state_Buffer_RecieveOutput_ToWrite;

        public Data()
        {
            arena = new FLORENCE.Frame.Cli.Dat.Arena();
            while (arena == null) { /* Wait while is created */ }

            data_Control = null;

            empty_InputBuffer = new FLORENCE.Frame.Cli.Dat.Input();
            while (empty_InputBuffer == null) { /* Wait while is created */ }
            empty_InputBuffer.InitialiseControl();

            empty_OutputBuffer = new FLORENCE.Frame.Cli.Dat.Output();
            while (empty_OutputBuffer == null) { /* Wait while is created */ }
            empty_OutputBuffer.InitialiseControl();

            inputDoubleBuffer = new FLORENCE.Frame.Cli.Dat.Input[2];
            for (byte index = 0; index < 2; index++)
            {
                inputDoubleBuffer[index] = empty_InputBuffer;
                while (inputDoubleBuffer[index] == null) { /* Wait while is created */ }
            }

            outputDoubleBuffer = new FLORENCE.Frame.Cli.Dat.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                outputDoubleBuffer[index] = empty_OutputBuffer;
                while (outputDoubleBuffer == null) { /* Wait while is created */ }
            }

            settings = new FLORENCE.Frame.Cli.Dat.Settings();
            while (settings == null) { /* Wait while is created */ }

            stack_InputActions = new List<FLORENCE.Frame.Cli.Dat.Input>();
            while (stack_InputActions == null) { /* Wait while is created */ }

            stack_OutputRecieves = new List<FLORENCE.Frame.Cli.Dat.Output>();
            while (stack_OutputRecieves == null) { /* Wait while is created */ }

            tramsnitInputDoubleBuffer = new FLORENCE.Frame.Cli.Dat.Input[2];
            for (byte index = 0; index < 2; index++)
            {
                tramsnitInputDoubleBuffer[index] = empty_InputBuffer;
                while (tramsnitInputDoubleBuffer[index] == null) { /* Wait while is created */ }
            }

            recieveOutputDoubleBuffer = new FLORENCE.Frame.Cli.Dat.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                recieveOutputDoubleBuffer[index] = empty_OutputBuffer;
                while (recieveOutputDoubleBuffer[index] == null) { /* Wait while is created */ }
            }

            user_IO = new FLORENCE.Frame.Cli.Dat.User_I();
            while (user_IO == null) { /* Wait while is created */ }

            mapDefault = new FLORENCE.Frame.Cli.Dat.Map_Default();
            while (mapDefault == null) { /* Wait while is created */ }
     
            state_Buffer_Input_ToWrite = true;
            state_Buffer_Output_ToWrite = false;
            state_Buffer_TransmitInput_ToWrite = true;
            state_Buffer_RecieveOutput_ToWrite = false;

            System.Console.WriteLine("FLORENCE: Data");
        }

        public UInt16 BoolToInt16(bool value)
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

        public void InitialiseControl()
        {
            data_Control = new FLORENCE.Frame.Cli.Dat.Data_Control();
            while (data_Control == null) { /* Wait while is created */ }
        }

        public void Flip_InBufferToWrite()
        {
            state_Buffer_Input_ToWrite = !state_Buffer_Input_ToWrite;
        }
        public void Flip_OutBufferToWrite()
        {
             state_Buffer_Output_ToWrite = !state_Buffer_Output_ToWrite;
        }
        public void Flip_Buffer_TransmitInput_ToWrite()
        {
            state_Buffer_TransmitInput_ToWrite = !state_Buffer_TransmitInput_ToWrite;
        }
        public void Flip_Buffer_RecieveOutput_ToWrite()
        {
            state_Buffer_RecieveOutput_ToWrite = !state_Buffer_RecieveOutput_ToWrite;
        }

        public FLORENCE.Frame.Cli.Dat.Arena GetArena()
        {
            return arena;
        }

        public FLORENCE.Frame.Cli.Dat.Data_Control GetData_Control()
        {
            return data_Control;
        }

        public FLORENCE.Frame.Cli.Dat.Input GetEmptyInput()
        {
            return empty_InputBuffer;   
        }
        public FLORENCE.Frame.Cli.Dat.Output GetEmptyOutput()
        {
            return empty_OutputBuffer;
        }

        public bool GetState_Buffer_Input_ToWrite()
        {
            return state_Buffer_Input_ToWrite;
        }
        public bool GetState_Buffer_Output_ToWrite()
        {
            return state_Buffer_Output_ToWrite;
        }
        public bool GetState_Buffer_TransmitInput_ToWrite()
        {
            return state_Buffer_TransmitInput_ToWrite;
        }
        public bool GetState_Buffer_RecieveOutput_ToWrite()
        {
            return state_Buffer_RecieveOutput_ToWrite;
        }

        public FLORENCE.Frame.Cli.Dat.Input GetBuffer_FrontInputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(GetState_Buffer_Input_ToWrite())];
        }
        public FLORENCE.Frame.Cli.Dat.Input GetBuffer_BackInputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(!GetState_Buffer_Input_ToWrite())];
        }
        public FLORENCE.Frame.Cli.Dat.Input GetBuffer_Front_TransmitInput()
        {
            return tramsnitInputDoubleBuffer[BoolToInt16(GetState_Buffer_TransmitInput_ToWrite())];
        }
        public FLORENCE.Frame.Cli.Dat.Input GetBuffer_Back_TransmitInput()
        {
            return tramsnitInputDoubleBuffer[BoolToInt16(!GetState_Buffer_TransmitInput_ToWrite())];
        }

        public FLORENCE.Frame.Cli.Dat.Map_Default GetMapDefault()
        {
            return mapDefault;
        }

        public FLORENCE.Frame.Cli.Dat.Settings GetSettings()
        {
            return settings;
        }
        public List<FLORENCE.Frame.Cli.Dat.Input> GetStackOfInputActions()
        {
            return stack_InputActions;
        }

        public List<FLORENCE.Frame.Cli.Dat.Output> GetStackOfOutputsRecieved()
        {
            return stack_OutputRecieves;
        }

        public FLORENCE.Frame.Cli.Dat.User_I GetUserIO()
        {
            return user_IO;
        }

        public void SetInputBuffer(FLORENCE.Frame.Cli.Dat.Input value)
        {
            inputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }

        public void SetOutputBuffer(FLORENCE.Frame.Cli.Dat.Output value)
        {
            outputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }
        public void SetTransmitBuffer(FLORENCE.Frame.Cli.Dat.Input value)
        {
            tramsnitInputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }

        public void SetRecieveBuffer(FLORENCE.Frame.Cli.Dat.Output value)
        {
            recieveOutputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }

        public void SetThirdInputBuffer(FLORENCE.Frame.Cli.Dat.Input value)
        {
            inputThirdBuffer = value;
        }

        public void SetThirdOutputBuffer(FLORENCE.Frame.Cli.Dat.Output value)
        {
            outputThirdBuffer = value;
        }
    }
}
