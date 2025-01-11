using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE
{
    public class Settings
    {
        private GameWindowSettings gws;
        private NativeWindowSettings nws;
        
        private ushort numberOfPlayers = 0;
        
        private static int refreshRate = 60;
        private static bool systemInitialised = false;

        public Settings()
        {
            Console.WriteLine("FLORENCE: Settings");
            gws = GameWindowSettings.Default;
            while (gws == null) { /* wait untill created */ }
            nws = NativeWindowSettings.Default;
            while (nws == null) { /* wait untill created */ }
            Set_refreshRate(60);
            //Set_systemInitialised(false);
            gws.UpdateFrequency = Get_refreshRate();
            nws.IsEventDriven = false;
            nws.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            nws.APIVersion = Version.Parse(input: "4.1");
            nws.AutoLoadBindings = true;
            nws.Location = new OpenTK.Mathematics.Vector2i(x: 100, y: 100);
            nws.ClientSize = new OpenTK.Mathematics.Vector2i(x: 1280, y: 720);
            nws.StartFocused = true;
            nws.StartVisible = true;
            nws.Title = "FLORENCE";

            numberOfPlayers = 0;
        }

        public GameWindowSettings GetGameWindowSettings()
        {
            return gws;
        }

        public NativeWindowSettings GetNativeWindowSettings()
        {
            return nws;
        }

        public ushort GetNumberOfPlayers() 
        {  
            return numberOfPlayers; 
        }

        public int Get_refreshRate()
        {
            return refreshRate;
        }

        public static bool Get_systemInitialised()
        {
            return systemInitialised;

        }

        public void Add_Player()
        {
            numberOfPlayers = (ushort)(numberOfPlayers + 1);
        }

        public void Set_refreshRate(int value)
        {
            refreshRate = value;
        }
    }
}
