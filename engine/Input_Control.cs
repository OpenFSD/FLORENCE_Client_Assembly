
namespace FLORENCE.Inputs
{
    public class Input_Control
    {
        static private OpenTK.Windowing.GraphicsLibraryFramework.Keys Keys = new OpenTK.Windowing.GraphicsLibraryFramework.Keys();
        
        public Input_Control()
        {

        }
/*
        public void CheckBufferAnomalyInFlagArray()
        {
            for (int praiseEventId = 0; praiseEventId < numberOfPraises; praiseEventId++)
            {
                switch (praiseEventId)
                {
                    case 0:
                        FLORENCE.Praise_Files.Praise0_Input obj_praise0 = (FLORENCE.Praise_Files.Praise0_Input)FLORENCE.Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_BackInputDouble().Get_InputBufferSubset();
                        if ((Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetMousePos().X != obj_praise0.Get_Mouse_X())
                            || (Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetMousePos().Y != obj_praise0.Get_Mouse_Y()))
                        {
                            isSelected_PraiseEventId[praiseEventId] = true;
                        }
                        break;

                    case 1:
                        FLORENCE.Praise_Files.Praise1_Input obj_praise1 = (FLORENCE.Praise_Files.Praise1_Input)FLORENCE.Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_BackInputDouble().Get_InputBufferSubset();
                        if (Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetPlayerPosition().X != obj_praise1.Get_Position_X())
                        {
                            isSelected_PraiseEventId[praiseEventId] = true;
                        }
                        if (Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetPlayerPosition().Y != obj_praise1.Get_Position_Y())
                        {
                            isSelected_PraiseEventId[praiseEventId] = true;
                        }
                        if (Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetPlayerPosition().Z != obj_praise1.Get_Position_Z())
                        {
                            isSelected_PraiseEventId[praiseEventId] = true;
                        }
                        break;

                    case 2:
                        break;

                    default:
                        break;
                }
            }
        }
*/
        public void LoadValuesInToInputSubset(
            ushort praiseEventId,
            float period
        )
        {
            FLORENCE.Input newSLot_Stack_InputAction = FLORENCE.Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_FrontInputDouble();
            newSLot_Stack_InputAction.SetPraiseEventId(praiseEventId);
            switch (praiseEventId)
            {
                case 0:
                    
                    break;

                case 1:
                    FLORENCE.Player data_Player_praise1 = (FLORENCE.Player)Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0);
                    FLORENCE.Praise_Files.Praise1_Input desternation_Subset = (FLORENCE.Praise_Files.Praise1_Input)Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_FrontInputDouble().Get_InputBufferSubset();
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
                    FLORENCE.Praise_Files.Praise0_Input obj_praise0 = (FLORENCE.Praise_Files.Praise0_Input)Framework.GetClient().GetData().GetUserIO().GetPraise0_Input();
                    Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_FrontInputDouble().Set_InputBuffer_SubSet(obj_praise0);
                    break;

		        case 1:
                    FLORENCE.Praise_Files.Praise1_Input obj_praise1 = (FLORENCE.Praise_Files.Praise1_Input)Framework.GetClient().GetData().GetUserIO().GetPraise1_Input();
                    Framework.GetClient().GetData().GetInput_Instnace().GetBuffer_FrontInputDouble().Set_InputBuffer_SubSet(obj_praise1);
                    break;
            }
		}
    }
}
