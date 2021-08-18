using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ AmongUS = () => Behav()
        .Init("Among Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Red Crewmate", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Red Crewmate", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Red Crewmate",
            new State(
                new ScaleHP(15000, 0),
                new State("first",
                    new Follow(0.9, 15, 0),
                    new Shoot(50, count: 6, projectileIndex: 0, shootAngle: 15, coolDown: 1600)
                    )
            ),
            new Threshold(1,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("MURDERS KNIFE", 0.01)
                )
            )
        ;
    }
}