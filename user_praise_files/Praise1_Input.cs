using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Praise_Files
{
    public class Praise1_Input
    {
        static private float position_X;
        static private float position_Y;
        static private float position_Z;
        static private float period;

        public Praise1_Input()
        {
            position_X = 0;
            position_Y = 0;
            position_Z = 0;
            period = 0;
        }

        public float Get_Position_X() 
        {   
            return position_X; 
        }

        public float Get_Position_Y()
        {
            return position_Y;
        }

        public float Get_Position_Z()
        {
            return position_Z;
        }

        public float GetPeriod()
        {
            return period;
        }
        
        public void Set_Position_X(float value) 
        {
            position_X = value;
        }
        
        public void Set_Position_Y(float value)
        {
            position_Y = value;
        }

        public void Set_Position_Z(float value)
        {
            position_Z = value;
        }

        public void Set_Period(float value)
        {
            period = value;
        }
    }
}
