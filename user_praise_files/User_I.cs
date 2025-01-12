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
        static private Client_Assembly.Praise_Files.Praise0_Input praise0_Input;
        static private Client_Assembly.Praise_Files.Praise1_Input praise1_Input;

        public User_I() 
        {
            praise0_Input = new Client_Assembly.Praise_Files.Praise0_Input();
            praise1_Input = new Client_Assembly.Praise_Files.Praise1_Input();
        }

        public Client_Assembly.Praise_Files.Praise0_Input GetPraise0_Input()
        {
            return praise0_Input;
        }

        public Client_Assembly.Praise_Files.Praise1_Input GetPraise1_Input()
        {
            return praise1_Input;
        }
    }
}
