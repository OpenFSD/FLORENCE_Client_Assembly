using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.Praise_Files
{
    public class Praise0_Output
    {
        static private bool ping_Active;

        public Praise0_Output()
        {
            ping_Active = false;
        }

        public bool GetFlag_IsPingActive()
        {
            return ping_Active;
        }

        public void SetFlag_IsPingActive(bool value)
        {
            ping_Active = value;
        }
    }
}
