using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli
{
    public class Global
    {
        static private bool flag_core_ACTIVE;
        static private bool flag_core_IDLE;
        
        static private bool[] flag_write_IDLE;
        static private bool[] flag_write_WAIT;
        static private bool[] flag_write_WRITE;
        
        static private int numberOfCores;

        public Global() 
        {
            flag_core_ACTIVE = true;
            flag_core_IDLE = false;

            flag_write_IDLE = new bool[2];
            flag_write_IDLE[0] = false;
            flag_write_IDLE[1] = false;
            flag_write_WAIT = new bool[2];
            flag_write_WAIT[0] = false;
            flag_write_WAIT[1] = true;
            flag_write_WRITE = new bool[2];
            flag_write_WRITE[0] = true;
            flag_write_WRITE[1] = false;
            
            numberOfCores = 4;
        }
        public bool GetConst_Core_ACTIVE()
        {
            return flag_core_ACTIVE;
        }
        public bool GetConst_Core_IDLE()
        {
            return flag_core_IDLE;
        }

        public bool GetConst_Write_IDLE(int index)
        {
            return flag_write_IDLE[index];
        }
        public bool GetConst_Write_WAIT(int index)
        {
            return flag_write_WAIT[index];
        }
        public bool GetConst_Write_WRITE(int index)
        {
            return flag_write_WRITE[index];
        }

        public int Get_NumCores()
        {
            return numberOfCores;
        }
    }
}
