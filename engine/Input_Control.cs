using OpenTK.Mathematics;

namespace Client_Assembly.Inputs
{
    public class Input_Control
    {
        static private OpenTK.Windowing.GraphicsLibraryFramework.Keys Keys = new OpenTK.Windowing.GraphicsLibraryFramework.Keys();
        
        public Input_Control()
        {

        }
        public void LoadValuesInToInputSubset(
            ushort praiseEventId,
            float period
        )
        {
            Client_Assembly.Inputs.Input newSLot_Stack_InputAction = Client_Assembly.Framework.GetClient().GetData().GetInput_Instnace().GetEmptyInput();
            newSLot_Stack_InputAction.SetPraiseEventId(praiseEventId);
            switch (praiseEventId)
            {
                case 0:

                    break;

                case 1:
                    Client_Assembly.Praise_Files.Praise1_Input desternation_Subset = (Client_Assembly.Praise_Files.Praise1_Input)Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().Get_InputBufferSubset();
                    Vector2 mouse = Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetMousePos();
                    desternation_Subset.Set_Mouse_X(mouse.X);
                    desternation_Subset.Set_Mouse_Y(mouse.Y);
                    break;
            }
        }

        public void SelectSetIntputSubset(
            int praiseEventId
        )
        {
            switch (praiseEventId)
            {
                case 0:
                    break;

                case 1:
                    Client_Assembly.Praise_Files.Praise1_Input obj_praise1 = (Client_Assembly.Praise_Files.Praise1_Input)Framework.GetClient().GetData().GetUserIO().GetPraise0_Input();
                    Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().Set_InputBuffer_SubSet(obj_praise1);
                    break;

		        case 2:
                    Client_Assembly.Praise_Files.Praise2_Input obj_praise2 = (Client_Assembly.Praise_Files.Praise2_Input)Framework.GetClient().GetData().GetUserIO().GetPraise1_Input();
                    Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().Set_InputBuffer_SubSet(obj_praise2);
                    break;
            }
		}
    }
}
