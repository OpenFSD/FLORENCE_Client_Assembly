using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLORENCE
{
    public class Game_Instance
    {
        static private FLORENCE.Frame.Cli.Dat.Arena arena;
        static private FLORENCE.Frame.Cli.Dat.Map_Default mapDefault;
        static private Settings settings;
        static private FLORENCE.Player[] player;

        public Game_Instance()
        {
            arena = new FLORENCE.Frame.Cli.Dat.Arena();
            while (arena == null) { /* Wait while is created */ }

            settings = new FLORENCE.Settings();
            while (settings == null) { /* Wait while is created */ }

            mapDefault = new FLORENCE.Frame.Cli.Dat.Map_Default();
            while (mapDefault == null) { /* Wait while is created */ }

            player = new FLORENCE.Player[2];
            for(ushort numberOfPlayers =0; numberOfPlayers < 2; numberOfPlayers++)
            {
                player[numberOfPlayers] = new FLORENCE.Player();
                while (player[numberOfPlayers] == null) { /* Wait while is created */ }
            }
        }

        public FLORENCE.Frame.Cli.Dat.Arena GetArena()
        {
            return arena;
        }

        public FLORENCE.Frame.Cli.Dat.Map_Default GetMapDefault()
        {
            return mapDefault;
        }

        public Settings GetSettings()
        {
            return settings;
        }

        public FLORENCE.Player GetPlayer(ushort index_playerID)
        {
            return player[index_playerID];
        }

        public void SetAdd_NewPlayer(FLORENCE.Player value)
        {
            settings.Add_Player();
            player = new FLORENCE.Player[settings.GetNumberOfPlayers()];

            player[settings.GetNumberOfPlayers()-1] = value;

        }
    }
}
