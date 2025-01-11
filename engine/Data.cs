using FLORENCE.Frame.Cli.Dat;
using FLORENCE.Inputs;
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
        static private FLORENCE.Settings settings;
        //byffers
        static private FLORENCE.Inputs.Input_Instance input_Instnace;
        static private FLORENCE.Outputs.Output_Instance output_Instnace;
        //stacks        
        static private List<FLORENCE.Input> stack_InputActions;
        static private List<FLORENCE.Output> stack_OutputRecieves;
        //praises
        static private FLORENCE.Praise_Files.User_I user_IO;

        static private bool state_Buffer_Input_ToWrite;
        static private bool state_Buffer_Output_ToWrite;

        public Data()
        {
            data_Control = null;
            gameInstance = new FLORENCE.Game_Instance();
            settings = new FLORENCE.Settings();
            input_Instnace = new FLORENCE.Inputs.Input_Instance();
            output_Instnace = new FLORENCE.Outputs.Output_Instance();   

            stack_InputActions = new List<FLORENCE.Input>();
            while (stack_InputActions == null) { /* Wait while is created */ }

            stack_OutputRecieves = new List<FLORENCE.Output>();
            while (stack_OutputRecieves == null) { /* Wait while is created */ }

            user_IO = new FLORENCE.Praise_Files.User_I();
            while (user_IO == null) { /* Wait while is created */ }

            state_Buffer_Input_ToWrite = true;
            state_Buffer_Output_ToWrite = false;

            System.Console.WriteLine("FLORENCE: Data");
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

        public FLORENCE.Game_Instance GetGame_Instance()
        {
            return gameInstance;
        }

        public FLORENCE.Inputs.Input_Instance GetInput_Instnace()
        {
            return input_Instnace;
        }
        public FLORENCE.Outputs.Output_Instance GetOutput_Instnace()
        {
            return output_Instnace;
        }

        public bool GetState_Buffer_Input_ToWrite()
        {
            return state_Buffer_Input_ToWrite;
        }
        public bool GetState_Buffer_Output_ToWrite()
        {
            return state_Buffer_Output_ToWrite;
        }

        public FLORENCE.Settings GetSettings()
        {
            return settings;
        }

        public List<FLORENCE.Input> GetStack_InputActions()
        {
            return stack_InputActions;
        }

        public List<FLORENCE.Output> GetStack_OutputsRecieved()
        {
            return stack_OutputRecieves;
        }

        public FLORENCE.Praise_Files.User_I GetUserIO()
        {
            return user_IO;
        }
    }
}
