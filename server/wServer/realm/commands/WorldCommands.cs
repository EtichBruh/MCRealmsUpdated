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
using File = TagLib.File;
using MarketResult = wServer.realm.entities.MarketResult;

namespace wServer.realm.commands
{
    class PositionCommand : Command
    {
        public PositionCommand() : base("pos", alias: "position") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.SendInfo("Current Position: " + (int)player.X + ", " + (int)player.Y);
            return true;
        }
    }

    class RealmCommand : Command
    {
        public RealmCommand() : base("realm") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.Realm,
                Name = "Realm"
            });
            return true;
        }
    }

    class NexusCommand : Command
    {
        public NexusCommand() : base("nexus") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.Nexus,
                Name = "Nexus"
            });
            return true;
        }
    }

    class DailyQuestCommand : Command
    {
        public DailyQuestCommand() : base("dailyquest") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.Tinker,
                Name = "Daily Quest Room"
            });
            return true;
        }
    }

    class VaultCommand : Command
    {
        public VaultCommand() : base("vault") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.Vault,
                Name = "Vault"
            });
            return true;
        }
    }

    class GhallCommand : Command
    {
        public GhallCommand() : base("ghall") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (player.GuildRank == -1)
            {
                player.SendError("You need to be in a guild.");
                return false;
            }
            player.Client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.GuildHall,
                Name = "Guild Hall"
            });
            return true;
        }
    }

    class GLandCommand : Command
    {
        public GLandCommand() : base("gland", alias: "glands") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            if (!(player.Owner is Realm))
            {
                player.SendError("This command requires you to be in realm first.");
                return false;
            }

            player.TeleportPosition(time, 1512 + 0.5f, 1048 + 0.5f);
            return true;
        }
    }

    class WhoCommand : Command
    {
        public WhoCommand() : base("who") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var owner = player.Owner;
            var players = owner.Players.Values
                .Where(p => p.Client != null && p.CanBeSeenBy(player))
                .ToArray();

            var sb = new StringBuilder($"Players in current area ({owner.Players.Count}): ");
            for (var i = 0; i < players.Length; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                sb.Append(players[i].Name);
            }

            player.SendInfo(sb.ToString());
            return true;
        }
    }

    class OnlineCommand : Command
    {
        public OnlineCommand() : base("online") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var servers = player.Manager.InterServer.GetServerList();
            var players =
                (from server in servers
                 from plr in server.playerList
                 where !plr.Hidden || player.Client.Account.Admin
                 select plr.Name)
                .ToArray();

            player.SendInfo("There are currently [" + players.Length + "] connected clients.");
            return true;
        }
    }

    class WhereCommand : Command
    {
        public WhereCommand() : base("where") { }

        protected override bool Process(Player player, RealmTime time, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                player.SendInfo("Usage: /where <player name>");
                return true;
            }

            var servers = player.Manager.InterServer.GetServerList();

            foreach (var server in servers)
                foreach (PlayerInfo plr in server.playerList)
                {
                    if (!plr.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                        plr.Hidden && !player.Client.Account.Admin)
                        continue;

                    player.SendInfo($"{plr.Name} is playing on {server.name} at [{plr.WorldInstance}]{plr.WorldName}.");
                    return true;
                }

            var pId = player.Manager.Database.ResolveId(name);
            if (pId == 0)
            {
                player.SendInfo($"No player with the name {name}.");
                return true;
            }

            var acc = player.Manager.Database.GetAccount(pId, "lastSeen");
            if (acc.LastSeen == 0)
            {
                player.SendInfo($"{name} not online. Has not been seen since the dawn of time.");
                return true;
            }

            var dt = Utils.FromUnixTimestamp(acc.LastSeen);
            player.SendInfo($"{name} not online. Player last seen {Utils.TimeAgo(dt)}.");
            return true;
        }
    }

    class ServerCommand : Command
    {
        public ServerCommand() : base("world") { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            player.SendInfo($"[{player.Owner.Id}] {player.Owner.GetDisplayName()} ({player.Owner.Players.Count} players)");
            return true;
        }
    }

    class RemoveAccountOverrideCommand : Command
    {
        public RemoveAccountOverrideCommand() : base("removeOverride", 0, listCommand: false) { }

        protected override bool Process(Player player, RealmTime time, string args)
        {
            var acc = player.Client.Account;
            if (acc.AccountIdOverrider == 0)
            {
                player.SendError("Account isn't overridden.");
                return false;
            }

            var overriderAcc = player.Manager.Database.GetAccount(acc.AccountIdOverrider);
            if (overriderAcc == null)
            {
                player.SendError("Account not found!");
                return false;
            }

            overriderAcc.AccountIdOverride = 0;
            overriderAcc.FlushAsync();
            player.SendInfo("Account override removed.");
            return true;
        }
    }

    class SpectateCommand : Command
    {
        public SpectateCommand() : base("spectate") { }

        protected override bool Process(Player player, RealmTime time, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                player.SendError("Usage: /spectate <player name>");
                return false;
            }

            var owner = player.Owner;
            if (!player.Client.Account.Admin && owner != null &&
                (owner is Arena || owner is ArenaSolo || owner is DeathArena))
            {
                player.SendInfo("Can't spectate in Arenas. (Temporary solution till we get spectate working across maps.)");
                return false;
            }

            var target = player.Owner.Players.Values
                .SingleOrDefault(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && p.CanBeSeenBy(player));

            if (target == null)
            {
                player.SendError("Player not found. Note: Target player must be on the same map.");
                return false;
            }

            if (!player.Client.Account.Admin &&
                player.Owner.EnemiesCollision.HitTest(player.X, player.Y, 8).OfType<Enemy>().Any())
            {
                player.SendError("Enemies cannot be nearby when initiating spectator mode.");
                return false;
            }

            if (player.SpectateTarget != null)
            {
                player.SpectateTarget.FocusLost -= player.ResetFocus;
                player.SpectateTarget.Controller = null;
            }

            if (player != target)
            {
                player.ApplyConditionEffect(ConditionEffectIndex.Paused);
                target.FocusLost += player.ResetFocus;
                player.SpectateTarget = target;
            }
            else
            {
                player.SpectateTarget = null;
                player.Owner.Timers.Add(new WorldTimer(3000, (w, t) =>
                {
                    if (player.SpectateTarget == null)
                        player.ApplyConditionEffect(ConditionEffectIndex.Paused, 0);
                }));
            }

            player.Client.SendPacket(new SetFocus()
            {
                ObjectId = target.Id
            });

            player.SendInfo($"Now spectating {target.Name}. Use the /self command to exit.");
            return true;
        }
    }

    class SelfCommand : Command
    {
        public SelfCommand() : base("self") { }

        protected override bool Process(Player player, RealmTime time, string name)
        {
            if (player.SpectateTarget != null)
            {
                player.SpectateTarget.FocusLost -= player.ResetFocus;
                player.SpectateTarget.Controller = null;
            }

            player.SpectateTarget = null;
            player.Sight.UpdateCount++;
            player.Owner.Timers.Add(new WorldTimer(3000, (w, t) =>
            {
                if (player.SpectateTarget == null)
                {
                    player.ApplyConditionEffect(ConditionEffectIndex.Paused, 0);
                    player.ApplyConditionEffect(ConditionEffectIndex.Hidden, 0);
                    player.ApplyConditionEffect(ConditionEffectIndex.Invincible, 0);
                    player.ApplyConditionEffect(ConditionEffectIndex.Stunned, 0);
                }
            }));
            player.Client.SendPacket(new SetFocus()
            {
                ObjectId = player.Id
            });
            return true;
        }
    }
}
