using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Global
    {
        static private int numberOfCores;
        static private int numberOfPraises;

        public Global() 
        {
            numberOfCores = 2;
            numberOfPraises = 3;
        }

        public int Get_NumCores()
        {
            return numberOfCores;
        }

        public int Get_NumberOfPraises()
        {
            return numberOfPraises;
        }
    }
}
