using System.Runtime.InteropServices;

namespace Client_Assembly
{
    public class Program
    {
        static private Client_Assembly.Framework framework;

        public static void Main(String[] args)
        {
            framework = new Client_Assembly.Framework();
            while (framework == null) { /* wait untill is created */ }
            Framework.GetClient().GetExecute().Create_And_Run_Graphics();

            System.Console.WriteLine("Client_Assembly START");//TEST
        }

        static public Client_Assembly.Framework GetFramework()
        {
            return framework;
        }
    }
}