//using FLORENCE.Frame.Cli.Dat.In;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Dat
{
    public class User_I
    {
        static private FLORENCE.Frame.Cli.Dat.UserIn.Praise0_Input praise0_Input;
        static private FLORENCE.Frame.Cli.Dat.UserIn.Praise1_Input praise1_Input;

        public User_I() 
        {
            praise0_Input = new FLORENCE.Frame.Cli.Dat.UserIn.Praise0_Input();
            praise1_Input = new FLORENCE.Frame.Cli.Dat.UserIn.Praise1_Input();
        }

        public FLORENCE.Frame.Cli.Dat.UserIn.Praise0_Input GetPraise0_Input()
        {
            return praise0_Input;
        }

        public FLORENCE.Frame.Cli.Dat.UserIn.Praise1_Input GetPraise1_Input()
        {
            return praise1_Input;
        }
    }
}
