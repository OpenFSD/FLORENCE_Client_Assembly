using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.Praise_Files
{
    public class Praise0_Algorithm
    {
        public Praise0_Algorithm() 
        { 
        
        }
        public void Do_Praise(
            Client_Assembly.Praise_Files.Praise0_Input in_SubSet,
            Client_Assembly.Praise_Files.Praise0_Output out_SubSet
        )
        {
            out_SubSet.SetFlag_IsPingActive(in_SubSet.GetFlag_IsPingActive());
        }
    }
}
