using FLORENCE.Frame.Cli.Dat.UserIn;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Dat.In
{
    public class Input_Control
    {
        static private bool[] isSelected_PraiseEventId = new bool[0];
        static int numberOfPraises;

        public Input_Control()
        {
            numberOfPraises = 2;//move to global
            isSelected_PraiseEventId = new bool[numberOfPraises];
        }

        public void CheckBufferAnomalyInFlagArray()
        {
            for (int praiseEventId = 0; praiseEventId < numberOfPraises; praiseEventId++)
            {
                switch (praiseEventId)
                {
                    case 0:
                        FLORENCE.Praise_Files.Praise0_Input obj_praise0 = (FLORENCE.Praise_Files.Praise0_Input)FLORENCE.Framework.GetClient().GetData().GetBuffer_BackInputDouble().Get_InputBufferSubset();
                        if ((Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetMousePos().X != obj_praise0.Get_Mouse_X())
                            || (Framework.GetClient().GetData().GetGame_Instance().GetPlayer(0).GetMousePos().Y != obj_praise0.Get_Mouse_Y()))
                        {
                            isSelected_PraiseEventId[praiseEventId] = true;
                        }
                        break;

                    case 1:
                        FLORENCE.Praise_Files.Praise1_Input obj_praise1 = (FLORENCE.Praise_Files.Praise1_Input)FLORENCE.Framework.GetClient().GetData().GetBuffer_BackInputDouble().Get_InputBufferSubset();
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

        public void LoadValuesInToInputSubset(
            int praiseEventId
        )
        {
            switch (praiseEventId)
            {
//===
//===
                case 0:
                    FLORENCE.Praise_Files.Praise0_Input subset_Praise0_Doublebuffer = (FLORENCE.Praise_Files.Praise0_Input)Framework.GetClient().GetData().GetBuffer_BackInputDouble().Get_InputBufferSubset();
                    List<FLORENCE.Input> stack_InputActions = (List<FLORENCE.Input>)Framework.GetClient().GetData().GetStackOfInputActions();
                    // TO DO STACK COUNTER, and implemntatoin as list INDEX
                    stack_InputActions.->Set_Mouse_X(subset_Praise0_Doublebuffer.Get_Mouse_X());
                    stack_InputActions.Set_Mouse_Y(subset_Praise0_Doublebuffer.Get_Mouse_X());
                    break;

                case 1:
                    FLORENCE.Praise_Files.Praise1_Input subset_Praise1_Doublebuffer = (FLORENCE.Praise_Files.Praise1_Input)Framework.GetClient().GetData().GetBuffer_BackInputDouble().Get_InputBufferSubset();
                    FLORENCE.Praise_Files.Praise1_Input subset_Praise1_thirdBuffer = (FLORENCE.Praise_Files.Praise1_Input)Framework.GetClient().GetData().GetThirdInputBuffer().Get_InputBufferSubset();
                    subset_Praise1_thirdBuffer.Set_Position_X(subset_Praise1_Doublebuffer.Get_Position_X());
                    subset_Praise1_thirdBuffer.Set_Position_Y(subset_Praise1_Doublebuffer.Get_Position_Y());
                    subset_Praise1_thirdBuffer.Set_Position_Z(subset_Praise1_Doublebuffer.Get_Position_Z());
                    break;
//===
//===
            }
        }
        public void SelectSetIntputSubset(
            int praiseEventId
        )
        {
            switch (praiseEventId)
            {
//===
//===
                case 0:
                    Framework.GetClient().GetData().GetThirdInputBuffer().Set_InputBuffer_SubSet(Framework.GetClient().GetData().GetUserIO().GetPraise0_Input());
                    break;

		        case 1:
                    Framework.GetClient().GetData().GetThirdInputBuffer().Set_InputBuffer_SubSet(Framework.GetClient().GetData().GetUserIO().GetPraise1_Input());
                    break;
//===
//===
            }
		}

        public int Get_NumberOfPraises()
        {
            return numberOfPraises;
        }

        public bool Get_IsSelected_PraiseEventId(int index)
        {
            return isSelected_PraiseEventId[index];
        }
        
        public void SetIsSelected_PraiseEventId(int index, bool value)
        {
            isSelected_PraiseEventId[index] = value;
        }
    }
}
