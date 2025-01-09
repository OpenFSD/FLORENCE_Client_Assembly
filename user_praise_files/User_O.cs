using FLORENCE.Frame.Cli.Dat.In;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Dat
{
    public class User_O
    {
        static private FLORENCE.Frame.Cli.Dat.UserOut.Praise0_Output praise0_Output;
        static private FLORENCE.Frame.Cli.Dat.UserOut.Praise1_Output praise1_Output;

        public User_O()
        {
            praise0_Output = new FLORENCE.Frame.Cli.Dat.UserOut.Praise0_Output();
            praise1_Output = new FLORENCE.Frame.Cli.Dat.UserOut.Praise1_Output();
        }

        public FLORENCE.Frame.Cli.Dat.UserOut.Praise0_Output GetPraise0_Outnput()
        {
            return praise0_Output;
        }

        public FLORENCE.Frame.Cli.Dat.UserOut.Praise1_Output GetPraise1_Output()
        {
            return praise1_Output;
        }
    }
}
