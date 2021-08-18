using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using common.resources;
using wServer.networking.packets.outgoing;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    class Bomb : Behavior
    {
        float radius;
        int damage;
        Cooldown coolDown;
        ConditionEffectIndex effect;
        int effectDuration;
        new uint color;

        public Bomb(double radius, int damage,
            double? fixedAngle = null, Cooldown coolDown = new Cooldown(), ConditionEffectIndex effect = 0, int effectDuration = 0, uint color = 0xffff0000)
        {
            this.radius = (float)radius;
            this.damage = damage;
            this.coolDown = coolDown.Normalize();
            this.effect = effect;
            this.effectDuration = effectDuration;
            this.color = color;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = 0;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            int cool = (int)state;

            if (cool <= 0)
            {
                if (host.HasConditionEffect(ConditionEffects.Stunned))
                    return;
                var target = new Position() { X = host.X, Y = host.Y};
                host.Owner.BroadcastPacketNearby(new Aoe()
                {
                    Pos = target,
                    Radius = radius,
                    Damage = (ushort)damage,
                    Duration = 0,
                    Effect = 0,
                    OrigType = host.ObjectType
                }, host, null, PacketPriority.Low);
                host.Owner.AOE(target, radius, true, p =>
                {
                    (p as IPlayer).Damage(damage, host);
                    if (!p.HasConditionEffect(ConditionEffects.Invincible) &&
                    !p.HasConditionEffect(ConditionEffects.Stasis))
                        p.ApplyConditionEffect(effect, effectDuration);
                });

                cool = coolDown.Next(Random);
            }
            else
            cool -= time.ElaspedMsDelta;
            state = cool;
        }
    }
}
