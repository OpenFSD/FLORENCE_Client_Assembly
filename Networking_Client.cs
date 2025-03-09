using Client_Assembly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Valve.Sockets;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Florence.NetworkingClient
{
    public class Networking
    {
        static private Valve.Sockets.NetworkingIdentity identity;
        static private uint connection;
        static private NetworkingSockets sockets = null;
        static private NetworkingMessage netMessage;
        
        public Networking()
        {
            connection = 0;
            sockets = new NetworkingSockets();
            netMessage = new NetworkingMessage();
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
                ret |= tmp << count - i - 1;
            }
            return ret;
        }
        static private bool[] ToBooleanArray(ushort value)
        {
            bool[] temp = new BitArray(new int[] { value }).Cast<bool>().ToArray();
            return temp;
        }

        static public byte ConvertBoolArrayToByte(bool[] source)
        {
            byte result = 0;
            // This assumes the array never contains more than 8 elements!
            int index = 8 - source.Length;

            // Loop through the array
            foreach (bool b in source)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }

        static public bool[] ConvertByteToBoolArray(byte b)
        {
            // prepare the return result
            bool[] result = new bool[8];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (int i = 0; i < 8; i++)
                result[i] = (b & (1 << i)) != 0;

            // reverse the array
            Array.Reverse(result);

            return result;
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

            address.SetAddress(Florence.NetworkingClient.Networking.Get_Local_IPAddress(), 3074);//ToDo

            connection = client.Connect(ref address);
            
            identity = new Valve.Sockets.NetworkingIdentity();

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

        public static void CreateAndSendNewMessage(byte praiseEventId)
        {
            Console.WriteLine("entered => CreateAndSendNewMessage()");//ToDo
            byte[] data = new byte[64];
            data[0] = praiseEventId;

            uint connection = Florence.NetworkingClient.Networking.Get_Connection();

            switch (praiseEventId)
            {
            case 0:
                bool[] array = Convert.ToString(connection, 2).Select(s => s.Equals('1')).ToArray();
                bool[] temp = new bool[8];
                int count = 0;
                while (count < array.Length)
                {
                    for (byte byte_index = 0; byte_index < 8; byte_index++)
                    {
                        temp[byte_index] = array.ElementAt(count);
                    }
                    data[count + 1] = Florence.NetworkingClient.Networking.ConvertBoolArrayToByte(temp);
                    count++;
                }
                break;

            case 1:

                break;
            }
            sockets.SendMessageToConnection(connection, data);//ToDo
        }

        public static void CopyPayloadFromMessage()
        {
            byte[] buffer = new byte[1024];
            netMessage.CopyTo(buffer);

            byte praiseEventId = 0;
            bool[] temp_bool_array = new bool[8];

            for (short i = 0; i < 8; i++)
            {
                temp_bool_array[i] = Convert.ToBoolean(buffer[i]);
            }
            praiseEventId = ConvertBoolArrayToByte(temp_bool_array);
            switch (praiseEventId)
            {
            case 0:

                break;

            case 1:

                break;
            }
        }

        public static void SetA_HookForDebugInformation()
        {
            DebugCallback debug = (type, message) =>
            {
                Console.WriteLine("Debug - Type: " + type + ", Message: " + message);
            };

            NetworkingUtils utils = new NetworkingUtils();

            utils.SetDebugCallback(DebugType.Everything, debug);
        }

        public static ref Valve.Sockets.NetworkingIdentity Get_Identity()
        {
            return ref identity;
        }
        
        private static string Get_Local_IPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static uint Get_Connection()
        {
            return connection;
        }
    }
}
