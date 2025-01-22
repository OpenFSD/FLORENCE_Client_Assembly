using Florence.WriteEnable;
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
        static private bool flag_IsLoaded_Stack_InputAction;
        static private bool flag_IsLoaded_Stack_OutputAction;
        
        public Data_Control() 
        { 
        
        }

        public void Push_Stack_InputActions(
            List<Client_Assembly.Inputs.Input> stack_InputAction,
            Client_Assembly.Inputs.Input buffer_Back_Input
        )
        {
            stack_InputAction.Add(buffer_Back_Input);
        }

        public void Push_Stack_OutputRecieve(
            List<Client_Assembly.Outputs.Output> stack_OutputRecieve,
            Client_Assembly.Outputs.Output buffer_TransmitOutput
        )
        {
            stack_OutputRecieve.Add(buffer_TransmitOutput);
        }

        public void Pop_Stack_InputActions(
            Client_Assembly.Inputs.Input buffer_Transmit_Input,
            List<Client_Assembly.Inputs.Input> stack_InputAction
        )
        {
            buffer_Transmit_Input = stack_InputAction.ElementAt(0);
            stack_InputAction.RemoveAt(0);
        }

        public void Pop_Stack_OutputRecieve(
            Client_Assembly.Outputs.Output buffer_Back_Output,
            List<Client_Assembly.Outputs.Output> stack_OutputRecieve
        )
        {
            buffer_Back_Output = stack_OutputRecieve.ElementAt(0);
            stack_OutputRecieve.RemoveAt(0);
        }

        public bool GetFlag_IsLoaded_Stack_InputAction()
        {
            return flag_IsLoaded_Stack_InputAction;
        }

        public bool GetFlag_IsLoaded_Stack_OutputAction()
        {
            return flag_IsLoaded_Stack_OutputAction;
        }

        public void SetFlag_InputStackLoaded(bool value)
        {
            flag_IsLoaded_Stack_InputAction = value;
        }
        public void SetFlag_OutputStackLoaded(bool value)
        {
            flag_IsLoaded_Stack_OutputAction = value;
        }
    }
}
