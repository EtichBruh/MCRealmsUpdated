using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using common;
using common.resources;
using TagLib;
using wServer.networking;
using wServer.realm.entities;
using wServer.realm.worlds;
using wServer.realm.worlds.logic;
using System.Collections.Generic;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using log4net;
using Newtonsoft.Json;
using File = TagLib.File;
using MarketResult = wServer.realm.entities.MarketResult;

namespace wServer.realm.commands
{
    class HelpCommand : Command
    {
        public HelpCommand() : base("commands") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            StringBuilder sb = new StringBuilder("Server Commands: ");
            var cmds = player.Manager.Commands.Commands.Values.Distinct()
                .Where(x => x.HasPermission(player) && x.ListCommand)
                .ToArray();
            Array.Sort(cmds, (c1, c2) => c1.CommandName.CompareTo(c2.CommandName));
            for (int i = 0; i < cmds.Length; i++)
            {
                if (i != 0) sb.Append(" | ");
                sb.Append(cmds[i].CommandName);
            }

            player.SendInfo(sb.ToString());
            return true;
        }
    }

    class UptimeCommand : Command
    {
        public UptimeCommand() : base("uptime") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(time.TotalElapsedMs);

            string answer = string.Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s:{4:D2}ms",
                            t.Days,
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);

            player.SendInfo("The server has been up for " + answer + ".");
            return true;
        }
    }
    class WipeServer : Command
    {
        public WipeServer() : base("wipeServer", permLevel: 100) { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            // close all worlds / disconnect all players
            foreach (var w in player.Manager.Worlds.Values)
            {
                w.Closed = true;
                foreach (var p in w.Players.Values)
                    p.Client.Disconnect();
            }

            player.Manager.Database.Wipe(player.Manager.Resources.GameData);

            Program.Stop();
            return true;
        }
    }

    class Level20Command : Command
    {
        public Level20Command() : base("level20", permLevel: 3,alias: "l20") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (player.Level < 20)
            {
                var statInfo = player.Manager.Resources.GameData.Classes[player.ObjectType].Stats;
                for (var v = 0; v < statInfo.Length; v++)
                {
                    player.Stats.Base[v] +=
                    (statInfo[v].MaxIncrease + statInfo[v].MinIncrease) * (21 - player.Level) / 2;
                    if (player.Stats.Base[v] > statInfo[v].MaxValue)
                        player.Stats.Base[v] = statInfo[v].MaxValue;
                }
                player.Level = 20;
                return true;
            }
            return false;
        }
    }
    class Level10Command : Command
    {
        public Level10Command() : base("level10", permLevel: 1, alias: "l10") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (player.Level < 10)
            {
                var statInfo = player.Manager.Resources.GameData.Classes[player.ObjectType].Stats;
                for (var v = 0; v < statInfo.Length; v++)
                {
                    player.Stats.Base[v] +=
                    (statInfo[v].MaxIncrease + statInfo[v].MinIncrease) * (21 - player.Level) / 2;
                    if (player.Stats.Base[v] > statInfo[v].MaxValue)
                        player.Stats.Base[v] = statInfo[v].MaxValue;
                }
                player.Level = 10;
                return true;
            }
            return false;
        }
    }
    class Level15Command : Command
    {
        public Level15Command() : base("level15", permLevel: 2, alias: "l15") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (player.Level < 15)
            {
                var statInfo = player.Manager.Resources.GameData.Classes[player.ObjectType].Stats;
                for (var v = 0; v < statInfo.Length; v++)
                {
                    player.Stats.Base[v] +=
                    (statInfo[v].MaxIncrease + statInfo[v].MinIncrease) * (21 - player.Level) / 2;
                    if (player.Stats.Base[v] > statInfo[v].MaxValue)
                        player.Stats.Base[v] = statInfo[v].MaxValue;
                }
                player.Level = 15;
                return true;
            }
            return false;
        }
    }
    class ResetServerFame : Command
    {
        public ResetServerFame() : base("resetFame", permLevel: 100) { }

        // resets leaderboards, account stars, and account fame to 0
        protected override bool Process(Player player, RealmTime time, string args)
        {
            // needed to make sure characters connected have fame reset properly
            foreach (var client in player.Manager.Clients.Values)
            {
                player.Experience = 0;
                player.Fame = 0;
            }

            Program.Stop();

            player.Manager.Database.ResetFame();
            return true;
        }
    }
    class SetFameCommand : Command
    {
        public SetFameCommand() : base("SetFame", permLevel: 110) { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var index = args.IndexOf(' ');
            if (string.IsNullOrEmpty(args) || index == -1)
            {
                player.SendInfo("Usage: /SetFame <player name> <fame>");
                return false;
            }

            var name = args.Substring(0, index);
            var fame = int.Parse(args.Substring(index + 1));

            if (Database.GuestNames.Contains(name, StringComparer.InvariantCultureIgnoreCase))
            {
                player.SendError("Cant add fame to guest.");
                return false;
            }

            var id = player.Manager.Database.ResolveId(name);

            var acc = player.Manager.Database.GetAccount(id);
            if (id == 0 || acc == null)
            {
                player.SendError("Account not found!");
                return false;
            }

            // kick player from server to set rank
            foreach (var i in player.Manager.Clients.Keys)
                if (i.Account.Name.EqualsIgnoreCase(name))
                    i.Disconnect();

            acc.Fame = fame;
            acc.FlushAsync();

            player.SendInfo($"That noob now have {fame} fame");
            return true;
        }
    }
}
