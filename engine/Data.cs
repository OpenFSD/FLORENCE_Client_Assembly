using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Data
    {
        static private Client_Assembly.Data_Control data_Control;
        static private Client_Assembly.Game_Instance gameInstance;
        static private Client_Assembly.game_Instance.Settings settings;
        //byffers
        static private Client_Assembly.Inputs.Input_Instance input_Instnace;
        static private Client_Assembly.Outputs.Output_Instance output_Instnace;
        //stacks        
        static private List<Client_Assembly.Inputs.Input> stack_InputActions;
        static private List<Client_Assembly.Outputs.Output> stack_OutputRecieves;
        //praises
        static private Client_Assembly.Praise_Files.User_I user_IO;

        static private bool state_Buffer_Input_ToWrite;
        static private bool state_Buffer_Output_ToWrite;

        public Data()
        {
            data_Control = null;
            
            gameInstance = new Client_Assembly.Game_Instance();
            while (gameInstance == null) { /* Wait while is created */ }

            settings = new Client_Assembly.game_Instance.Settings();
            while (settings == null) { /* Wait while is created */ }

            input_Instnace = new Client_Assembly.Inputs.Input_Instance();
            while (input_Instnace == null) { /* Wait while is created */ }

            output_Instnace = new Client_Assembly.Outputs.Output_Instance();
            while (output_Instnace == null) { /* Wait while is created */ }

            stack_InputActions = new List<Client_Assembly.Inputs.Input>();
            while (stack_InputActions == null) { /* Wait while is created */ }

            stack_OutputRecieves = new List<Client_Assembly.Outputs.Output>();
            while (stack_OutputRecieves == null) { /* Wait while is created */ }

            user_IO = new Client_Assembly.Praise_Files.User_I();
            while (user_IO == null) { /* Wait while is created */ }

            state_Buffer_Input_ToWrite = true;
            state_Buffer_Output_ToWrite = false;

            System.Console.WriteLine("Client_Assembly: Data");
        }

        public void InitialiseControl()
        {
            data_Control = new Client_Assembly.Data_Control();
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

        public Client_Assembly.Data_Control GetData_Control()
        {
            return data_Control;
        }

        public Client_Assembly.Game_Instance GetGame_Instance()
        {
            return gameInstance;
        }

        public Client_Assembly.Inputs.Input_Instance GetInput_Instnace()
        {
            return input_Instnace;
        }
        public Client_Assembly.Outputs.Output_Instance GetOutput_Instnace()
        {
            return output_Instnace;
        }

        public bool GetState_Buffer_InputPraise_SideToWrite()
        {
            return state_Buffer_Input_ToWrite;
        }
        public bool GetState_Buffer_OutputPraise_SideToWrite()
        {
            return state_Buffer_Output_ToWrite;
        }

        public Client_Assembly.game_Instance.Settings GetSettings()
        {
            return settings;
        }

        public List<Client_Assembly.Inputs.Input> GetStack_InputActions()
        {
            return stack_InputActions;
        }

        public List<Client_Assembly.Outputs.Output> GetStack_OutputsRecieved()
        {
            return stack_OutputRecieves;
        }

        public Client_Assembly.Praise_Files.User_I GetUserIO()
        {
            return user_IO;
        }
    }
}
