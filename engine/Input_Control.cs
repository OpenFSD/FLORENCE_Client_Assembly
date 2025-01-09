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
                        if ((Framework.GetClient().GetData().GetBuffer_BackInputDouble().GetPlayer().GetMousePos().X != Framework.GetClient().GetData().GetThirdInputBuffer().GetPlayer().GetMousePos().X)
                            || (Framework.GetClient().GetData().GetBuffer_BackInputDouble().GetPlayer().GetMousePos().Y != Framework.GetClient().GetData().GetThirdInputBuffer().GetPlayer().GetMousePos().Y))
                        {
                            isSelected_PraiseEventId[praiseEventId] = true;
                        }
                        break;

                    case 1:
                        if (Framework.GetClient().GetData().GetBuffer_BackInputDouble().GetPlayer().GetPlayerPosition() != Framework.GetClient().GetData().GetThirdInputBuffer().GetPlayer().GetPlayerPosition())
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
                    Praise0_Input subset_Praise0_Doublebuffer = (Praise0_Input)Framework.GetClient().GetData().GetBuffer_BackInputDouble().Get_InputBufferSubset();
                    Praise0_Input subset_Praise0_thirdBuffer = (Praise0_Input)Framework.GetClient().GetData().GetThirdInputBuffer().Get_InputBufferSubset();
                    subset_Praise0_thirdBuffer.Set_Mouse_X(subset_Praise0_Doublebuffer.Get_Mouse_X());
                    subset_Praise0_thirdBuffer.Set_Mouse_Y(subset_Praise0_Doublebuffer.Get_Mouse_X());
                    break;

                case 1:
                    Praise1_Input subset_Praise1_Doublebuffer = (Praise1_Input)Framework.GetClient().GetData().GetBuffer_BackInputDouble().Get_InputBufferSubset();
                    Praise1_Input subset_Praise1_thirdBuffer = (Praise1_Input)Framework.GetClient().GetData().GetThirdInputBuffer().Get_InputBufferSubset();
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
