
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
                    Client_Assembly.game_Instance.Player data_Player_praise1 = (Client_Assembly.game_Instance.Player)Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0);
                    Client_Assembly.Praise_Files.Praise1_Input desternation_Subset = (Client_Assembly.Praise_Files.Praise1_Input)newSLot_Stack_InputAction.Get_InputBufferSubset();
                    desternation_Subset.Set_Position_X(data_Player_praise1.GetPlayerPosition().X);
                    desternation_Subset.Set_Position_Y(data_Player_praise1.GetPlayerPosition().X);
                    desternation_Subset.Set_Position_Z(data_Player_praise1.GetPlayerPosition().X);
                    desternation_Subset.Set_Period(period);
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
                    Client_Assembly.Praise_Files.Praise0_Input obj_praise0 = (Client_Assembly.Praise_Files.Praise0_Input)Framework.GetClient().GetData().GetUserIO().GetPraise0_Input();
                    Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_Front_InputDouble().Set_InputBuffer_SubSet(obj_praise0);
                    break;

		        case 1:
                    Client_Assembly.Praise_Files.Praise1_Input obj_praise1 = (Client_Assembly.Praise_Files.Praise1_Input)Framework.GetClient().GetData().GetUserIO().GetPraise1_Input();
                    Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_Front_InputDouble().Set_InputBuffer_SubSet(obj_praise1);
                    break;
            }
		}
    }
}
