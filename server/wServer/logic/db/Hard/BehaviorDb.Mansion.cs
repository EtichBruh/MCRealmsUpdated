    using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Mansion = () => Behav()
        .Init("Mansion Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Vindicator", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Vindicator", 1, coolDown: 100),
                    new TimedTransition(500, "second")
                    ),
                new State("second",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Evoker", 999, "db2")
                    ),
                new State("db2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn2")
                    ),
                new State("spawn2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Evoker", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Vindicator",
            new State(
                new State("first",
                    new Follow(1.2, range: 0, coolDown: 0),
                    new Shoot(40, count: 2, projectileIndex: 1, shootAngle: 15, coolDown: 800)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Vindicator's Ram Axe", 0.009),
                    new ItemLoot("Totem of Undying", 0.009)
                )
            )
       .Init("MC Evoker",
            new State(
                new State("first",
                    new Follow(1.2, range: 0, coolDown: 0),
                    new Bomb(8, 600, coolDown: 700, effect: ConditionEffectIndex.Slowed, effectDuration: 1500),
                    new Bomb(8, 600, coolDown: 2100, effect: ConditionEffectIndex.ArmorBroken, effectDuration: 1500)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Evokers Powerful Potion", 0.009),
                    new ItemLoot("Totem of Undying", 0.009)
                )
            )
        ;
    }
}