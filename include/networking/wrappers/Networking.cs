using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Valve.Sockets;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client_Assembly
{
    public class Networking
    {
        static private Valve.Sockets.NetworkingSockets sockets = null;
        static private Valve.Sockets.NetworkingMessage netMessage;
        
        public Networking()
        {
            sockets = new NetworkingSockets();
            netMessage = new Valve.Sockets.NetworkingMessage();
        }
        static private int BoolToInt(bool value)
        {
            int temp = 0;
            if (value) temp = 1;
            if (!value) temp = 0;
            return temp;
        }

        static private int BitArrayToInt(bool[] arr, int count)
        {
            int ret = 0;
            int tmp;
            for (int i = 0; i < count; i++)
            {
                tmp = BoolToInt(arr[i]);
                ret |= tmp << (count - i - 1);
            }
            return ret;
        }
        static private bool[] ToBooleanArray(UInt16 value)
        {
            bool[] temp = new BitArray(new int[] { value }).Cast<bool>().ToArray();
            return temp;
        }

        static public void CreateNetworkingClient()
        {
            NetworkingSockets client = new NetworkingSockets();

            uint connection = 0;

            StatusCallback status = (ref StatusInfo info) => {
                switch (info.connectionInfo.state)
                {
                    case ConnectionState.None:
                        break;

                    case ConnectionState.Connected:
                        Console.WriteLine("Client connected to server - ID: " + connection);
                        CopyPayloadFromMessage();
                        break;

                    case ConnectionState.ClosedByPeer:
                    case ConnectionState.ProblemDetectedLocally:
                        client.CloseConnection(connection);
                        Console.WriteLine("Client disconnected from server");
                        break;
                }
            };

            NetworkingUtils utils = new NetworkingUtils();
            utils.SetStatusCallback(status);

            Address address = new Address();

            //address.SetAddress("::1", port);//TODO

            connection = client.Connect(ref address);

#if VALVESOCKETS_SPAN
	MessageCallback message = (in NetworkingMessage netMessage) => {
		Console.WriteLine("Message received from server - Channel ID: " + netMessage.channel + ", Data length: " + netMessage.length);
	};
#else
            const int maxMessages = 20;

            NetworkingMessage[] netMessages = new NetworkingMessage[maxMessages];
#endif

            while (!Console.KeyAvailable)
            {
                client.RunCallbacks();

#if VALVESOCKETS_SPAN
		client.ReceiveMessagesOnConnection(connection, message, 20);
#else
                int netMessagesCount = client.ReceiveMessagesOnConnection(connection, netMessages, maxMessages);

                if (netMessagesCount > 0)
                {
                    for (int i = 0; i < netMessagesCount; i++)
                    {
                        ref NetworkingMessage netMessage = ref netMessages[i];

                        Console.WriteLine("Message received from server - Channel ID: " + netMessage.channel + ", Data length: " + netMessage.length);
                        CopyPayloadFromMessage();//added

                        netMessage.Destroy();
                    }
                }
#endif

                Thread.Sleep(15);
            }
        }

        public static void CreateAndSendNewMessage(UInt16 switch_praiseEventId)
        {
            byte[] data = new byte[64];
            bool[] temp_bool_array = new bool[16];

            byte[] intBytes = null;
            intBytes = BitConverter.GetBytes(switch_praiseEventId);
            for (ushort index = 0; index < intBytes.Length; index++)
            {
                data[index] = intBytes[index];
            }

            switch (switch_praiseEventId)
            {
                case 0:
                    //Client_Assembly.Praise_Files.Praise0_Input subSet_praise0 = (Client_Assembly.Praise_Files.Praise0_Input)Client_Assembly.Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().Get_InputBufferSubset();
                    break;

                case 1:
                    Client_Assembly.Praise_Files.Praise1_Input subSet_praise1 = (Client_Assembly.Praise_Files.Praise1_Input)Client_Assembly.Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().Get_InputBufferSubset();
                    for (ushort index = 16; index < 32; index++)
                    {
                        intBytes = BitConverter.GetBytes(subSet_praise1.Get_Mouse_X());
                        data[index] = intBytes[index];
                    }
                    for (ushort index = 32; index < 48; index++)
                    {
                        intBytes = BitConverter.GetBytes(subSet_praise1.Get_Mouse_Y());
                        data[index] = intBytes[index];
                    }
                    for (ushort index = 48; index < 64; index++)
                    {
                        data[index] = new byte();
                    }
                    break;

                case 2:
                    //Client_Assembly.Praise_Files.Praise2_Input subSet_praise2 = (Client_Assembly.Praise_Files.Praise2_Input)Client_Assembly.Framework.GetClient().GetData().GetInput_Instnace().Get_Transmit_InputBuffer().Get_InputBufferSubset();
                    break;

                default:
                    break;
            }
            //Sockets.SendMessageToConnection(connection, data)//TODO
        }

        public static void CopyPayloadFromMessage()
        {
            byte[] buffer = new byte[1024];
            netMessage.CopyTo(buffer);

            int switch_praiseEventId = 0;
            bool[] temp_bool_array;

            for (Int16 i = 0; i < 16; i++)
            {
                temp_bool_array = new bool[16];
                temp_bool_array[i] = Convert.ToBoolean(buffer[i]);
                switch_praiseEventId = Networking.BitArrayToInt(temp_bool_array, 16); ;
            }
            switch (switch_praiseEventId)
            {
                case 0:
                    for (Int16 i = 16; i < 16; i++)
                    {
                        temp_bool_array = new bool[16];
                        temp_bool_array[i] = Convert.ToBoolean(buffer[i]);
                        //FLORENCE.Framework.GetServer()->GetData()->GetInputBuffer(FLORENCE.Framework.GetServer()->GetData()->GetStateOfInBufferWrite())->
                    }
                    //data = new byte[64];
                    break;

                case 1:
                    //ToDo
                    break;

                default:
                    break;
            }
        }

        public static void SetA_HookForDebugInformation()
        {
            Valve.Sockets.DebugCallback debug = (type, message) =>
            {
                Console.WriteLine("Debug - Type: " + type + ", Message: " + message);
            };

            Valve.Sockets.NetworkingUtils utils = new Valve.Sockets.NetworkingUtils();

            utils.SetDebugCallback(Valve.Sockets.DebugType.Everything, debug);
        }


    }
}
