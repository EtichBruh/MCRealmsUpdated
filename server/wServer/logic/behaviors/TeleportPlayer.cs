using System;
using System.Linq;
using common.resources;
using wServer.networking.packets.outgoing;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    class TeleportPlayer : Behavior
    {
        private int _x;
        private int _y;

        public TeleportPlayer(int x, int y)
        {
            _x = x;
            _y = y;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = 0;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            foreach (var entity in host.GetNearestEntities(1, null, true).OfType<Player>())
            {

                if (entity.Owner == null)
                    continue;

                Position pos = new Position() { X = _x, Y = _y };

                entity.TeleportPosition(time, pos, true);
            }
        }
    }
}
