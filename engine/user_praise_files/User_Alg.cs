using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly.Praise_Files
{
    public class User_Alg
    {
        static private Client_Assembly.Praise_Files.Praise0_Algorithm praise0_Algorithm = null;
        static private Client_Assembly.Praise_Files.Praise1_Algorithm praise1_Algorithm = null;

        public User_Alg() 
        {
            praise0_Algorithm = new Client_Assembly.Praise_Files.Praise0_Algorithm();
            while (praise0_Algorithm == null) { /* Wait while is created */ }

            praise1_Algorithm = new Client_Assembly.Praise_Files.Praise1_Algorithm();
            while (praise1_Algorithm == null) { /* Wait while is created */ }
        }

        public Client_Assembly.Praise_Files.Praise0_Algorithm GetPraise0_Algorithm()
        {
            return praise0_Algorithm;
        }
    }
}
