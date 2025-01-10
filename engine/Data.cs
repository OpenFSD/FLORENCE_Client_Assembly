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
        static private FLORENCE.Frame.Cli.Dat.Data_Control data_Control;
        static private FLORENCE.Game_Instance gameInstance;
        //byffers
        static private FLORENCE.Input empty_InputBuffer;
        static private FLORENCE.Output empty_OutputBuffer;
        static private FLORENCE.Input[] inputDoubleBuffer;
        static private FLORENCE.Output[] outputDoubleBuffer;
        static private FLORENCE.Input transmitInputBuffer;
        static private FLORENCE.Output transmitOutputBuffer;
        //stacks        
        static private List<FLORENCE.Input> stack_InputActions;
        static private List<FLORENCE.Output> stack_OutputRecieves;
        //praises
        static private FLORENCE.Frame.Cli.Dat.User_I user_IO;

        static private bool state_Buffer_Input_ToWrite;
        static private bool state_Buffer_Output_ToWrite;

        public Data()
        {
            data_Control = null;

            empty_InputBuffer = new FLORENCE.Input();
            while (empty_InputBuffer == null) { /* Wait while is created */ }
            empty_InputBuffer.InitialiseControl();

            empty_OutputBuffer = new FLORENCE.Output();
            while (empty_OutputBuffer == null) { /* Wait while is created */ }
            empty_OutputBuffer.InitialiseControl();

            inputDoubleBuffer = new FLORENCE.Input[2];
            for (byte index = 0; index < 2; index++)
            {
                inputDoubleBuffer[index] = empty_InputBuffer;
                while (inputDoubleBuffer[index] == null) { /* Wait while is created */ }
            }

            outputDoubleBuffer = new FLORENCE.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                outputDoubleBuffer[index] = empty_OutputBuffer;
                while (outputDoubleBuffer == null) { /* Wait while is created */ }
            }

            stack_InputActions = new List<FLORENCE.Input>();
            while (stack_InputActions == null) { /* Wait while is created */ }

            stack_OutputRecieves = new List<FLORENCE.Output>();
            while (stack_OutputRecieves == null) { /* Wait while is created */ }

            transmitInputBuffer = new FLORENCE.Input();
            while (stack_InputActions == null) { /* Wait while is created */ }

            transmitOutputBuffer = new FLORENCE.Output();
            while (stack_InputActions == null) { /* Wait while is created */ }

            user_IO = new FLORENCE.Frame.Cli.Dat.User_I();
            while (user_IO == null) { /* Wait while is created */ }

            state_Buffer_Input_ToWrite = true;
            state_Buffer_Output_ToWrite = false;

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

        public FLORENCE.Frame.Cli.Dat.Data_Control GetData_Control()
        {
            return data_Control;
        }

        public FLORENCE.Input GetEmptyInput()
        {
            return empty_InputBuffer;
        }
        public FLORENCE.Output GetEmptyOutput()
        {
            return empty_OutputBuffer;
        }

        public FLORENCE.Game_Instance GetGame_Instance()
        {
            return gameInstance;
        }   

        public bool GetState_Buffer_Input_ToWrite()
        {
            return state_Buffer_Input_ToWrite;
        }
        public bool GetState_Buffer_Output_ToWrite()
        {
            return state_Buffer_Output_ToWrite;
        }
        public FLORENCE.Input GetBuffer_FrontInputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(GetState_Buffer_Input_ToWrite())];
        }
        public FLORENCE.Input GetBuffer_BackInputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(!GetState_Buffer_Input_ToWrite())];
        }

        public FLORENCE.Output GetBuffer_FrontOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(GetState_Buffer_Output_ToWrite())];
        }
        public FLORENCE.Output GetBuffer_BackOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(!GetState_Buffer_Output_ToWrite())];
        }

        public List<FLORENCE.Input> GetStackOfInputActions()
        {
            return stack_InputActions;
        }

        public List<FLORENCE.Output> GetStackOfOutputsRecieved()
        {
            return stack_OutputRecieves;
        }
        public FLORENCE.Input GetTransmitInputBuffer()
        {
            return transmitInputBuffer;
        }

        public FLORENCE.Output GetTransmitOutputBuffer()
        {
            return transmitOutputBuffer;
        }

        public FLORENCE.Frame.Cli.Dat.User_I GetUserIO()
        {
            return user_IO;
        }

        public void SetInputBuffer(FLORENCE.Input value)
        {
            inputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }

        public void SetOutputBuffer(FLORENCE.Output value)
        {
            outputDoubleBuffer[BoolToInt16(Framework.GetClient().GetData().GetState_Buffer_Input_ToWrite())] = value;
        }
    }
}
