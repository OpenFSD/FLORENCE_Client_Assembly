using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.Outputs
{
    public class Output_Control
    {
        public Output_Control() 
        {

        }

        void SelectSetOutputSubset(
            int praiseEventId
        )
        {
            switch (praiseEventId)
            {
                case 0:
                    Client_Assembly.Framework.GetClient().GetData().GetOutput_Instnace().GetBuffer_BackOutputDouble().SetInputBufferSubSet(Framework.GetClient().GetData().GetUserIO().GetPraise1_Input());
                    break;

                case 1:
                    Client_Assembly.Framework.GetClient().GetData().GetOutput_Instnace().GetBuffer_BackOutputDouble().SetInputBufferSubSet(Framework.GetClient().GetData().GetUserIO().GetPraise0_Input());
                    break;
            }
        }
    }
}
