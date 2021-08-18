using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SeaTemple = () => Behav()
        .Init("Guardian Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Elder Guardian", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Elder Guardian", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Elder Guardian",
            new State(
                new ScaleHP(15000, 0),
                new State("first",
                    new Follow(0.6, 15, 0),
                    new Shoot(50, count: 3, projectileIndex: 0, shootAngle: 15, coolDown: 1250),
                    new Shoot(50, count: 2, projectileIndex: 1, shootAngle: 15, coolDown: 2500),
                    new Bomb(3, 80, coolDown: 2500, effect: ConditionEffectIndex.Slowed, effectDuration: 1000)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Sea Crystal", 0.05),
                    new ItemLoot("Sea Shard", 0.05),
                    new ItemLoot("Enchanted Sea Crystal", 0.015),
                    new ItemLoot("Enchanted Sea Shard", 0.015),
                    new ItemLoot("The Tail of the Elder Guardian", 0.01),
                    new ItemLoot("The Skin of the Elder Guardian", 0.009),
                    new ItemLoot("Diamond", 0.75)
                )
            )
        ;
    }
}