using System.Runtime.InteropServices;

namespace FLORENCE
{
    public class Program
    {
        static private FLORENCE.Framework framework;

        public static void Main(String[] args)
        {
            framework = new FLORENCE.Framework();
            while (framework == null) { /* wait untill is created */ }
            Framework.GetClient().GetExecute().Create_And_Run_Graphics();

            System.Console.WriteLine("FLORENCE START");//TEST
        }

        static public FLORENCE.Framework GetFramework()
        {
            return framework;
        }
    }
}