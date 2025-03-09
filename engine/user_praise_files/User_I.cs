using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.Praise_Files
{
    public class User_I
    {
        static private Client_Assembly.Praise_Files.Praise1_Input praise1_Input;
        static private Client_Assembly.Praise_Files.Praise2_Input praise2_Input;

        public User_I() 
        {
            praise1_Input = new Client_Assembly.Praise_Files.Praise1_Input();
            praise2_Input = new Client_Assembly.Praise_Files.Praise2_Input();
        }

        public Client_Assembly.Praise_Files.Praise1_Input GetPraise0_Input()
        {
            return praise1_Input;
        }

        public Client_Assembly.Praise_Files.Praise2_Input GetPraise1_Input()
        {
            return praise2_Input;
        }
    }
}
