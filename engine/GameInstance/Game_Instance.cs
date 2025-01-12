using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Assembly
{
    public class Game_Instance
    {
        static private Client_Assembly.game_Instance.Arena arena;
        static private Client_Assembly.game_Instance.Map_Default mapDefault;
        static private Client_Assembly.game_Instance.Settings settings;
        static private Client_Assembly.game_Instance.Player[] player;

        public Game_Instance()
        {
            arena = new Client_Assembly.game_Instance.Arena();
            while (arena == null) { /* Wait while is created */ }

            settings = new Client_Assembly.game_Instance.Settings();
            while (settings == null) { /* Wait while is created */ }

            mapDefault = new Client_Assembly.game_Instance.Map_Default();
            while (mapDefault == null) { /* Wait while is created */ }

            player = new Client_Assembly.game_Instance.Player[2];
            for(ushort numberOfPlayers =0; numberOfPlayers < 2; numberOfPlayers++)
            {
                player[numberOfPlayers] = new Client_Assembly.game_Instance.Player();
                while (player[numberOfPlayers] == null) { /* Wait while is created */ }
            }
        }
        public void Initalise_Graphics()
        {
            using (var graphics = new Client_Assembly.game_Instance.gFX.Graphics(
                Framework.GetClient().GetData().GetGame_Instance().GetSettings().GetGameWindowSettings(),
                Framework.GetClient().GetData().GetGame_Instance().GetSettings().GetNativeWindowSettings()
            ))
            {
                graphics.Run();
            }
        }

        public Client_Assembly.game_Instance.Arena GetArena()
        {
            return arena;
        }

        public Client_Assembly.game_Instance.Map_Default GetMapDefault()
        {
            return mapDefault;
        }

        public Client_Assembly.game_Instance.Settings GetSettings()
        {
            return settings;
        }

        public Client_Assembly.game_Instance.Player GetPlayer(ushort index_playerID)
        {
            return player[index_playerID];
        }

        public void SetAdd_NewPlayer(Client_Assembly.game_Instance.Player value)
        {/*
            settings.Add_Player();
            player = new Client_Assembly.Player[settings.GetNumberOfPlayers()];

            player[settings.GetNumberOfPlayers()-1] = value;

        */}
    }
}
