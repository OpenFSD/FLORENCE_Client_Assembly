using FLORENCE.Frame.Cli.Dat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE.Frame.Cli.Algo.In
{
    public class IO_ListenRespond_Control
    {
        static bool flag_IO_ThreadState;

        public IO_ListenRespond_Control()
        {
            flag_IO_ThreadState = true;
        }
        public bool GetFlag_IO_ThreadState()
        {
            return flag_IO_ThreadState;
        }

        public void SetFlag_IO_ThreadState(bool value)
        {
            flag_IO_ThreadState = value;
        }
    }
}
