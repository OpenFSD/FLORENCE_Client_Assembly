using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Dat.UserIn
{
    public class Praise0_Input
    {
        static private Int16 mouse_X;
        static private Int16 mouse_Y;

        public Praise0_Input()
        {
            mouse_X = 0;
            mouse_Y = 0;
        }

        public Int16 Get_Mouse_X() 
        {   
            return mouse_X; 
        }

        public Int16 Get_Mouse_Y()
        {
            return mouse_Y;
        }

        public void Set_Mouse_X(Int16 value) 
        {
            mouse_X = value;
        }
        
        public void Set_Mouse_Y(Int16 value)
        {
            mouse_Y = value;
        }
    }
}
