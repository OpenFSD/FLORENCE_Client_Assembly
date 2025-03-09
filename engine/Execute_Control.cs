using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Client_Assembly
{
    public class Execute_Control
    {
        static private bool flag_SystemInitialised;
        static private bool[] flag_ThreadInitialised;

        public Execute_Control(int numberOfCores)
        {
            flag_SystemInitialised = new bool();
            flag_SystemInitialised = true;

            flag_ThreadInitialised = new bool[numberOfCores];
            for(byte index = 0; index < numberOfCores; index++)
            {
                flag_ThreadInitialised[index] = new bool();
                flag_ThreadInitialised[index] = true;
            }
        }

        public bool GetFlag_Client_App_Initialised()
        {
            flag_SystemInitialised = false;
            for (byte index = 0; index < Client_Assembly.Framework.GetClient().GetGlobal().Get_NumCores(); index++)
            {
                if (flag_ThreadInitialised[index] == true)
                {
                    flag_SystemInitialised = true;
                }
            }
            return flag_SystemInitialised;
        }

        public bool GetFlag_ThreadInitialised(byte coreId)
        {
            return flag_ThreadInitialised[coreId];
        }

        public void SetConditionCodeOfThisThreadedCore(byte coreId)
        {
            //Todo
            SetFlag_ThreadInitialised(coreId, false);
        }

        public void SetFlag_ThreadInitialised(byte coreId, bool value)
        {
            flag_ThreadInitialised[coreId] = false;
        }
    }
}
