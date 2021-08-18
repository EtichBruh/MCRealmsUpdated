using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Temple = () => Behav()
        .Init("Herobrine Monster Spawner",
            new State(			
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Herobrine", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Herobrine", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Herobrine",
            new State(
			    new ScaleHP(15000, 0),						
                new State("first",
                    new Shoot(30, count: 5, projectileIndex: 0, shootAngle: 10, coolDown: 1200),
                    new Shoot(30, count: 3, projectileIndex: 0, rotateAngle: 2, fixedAngle: 2, coolDown: 50)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Herobrine Head", 0.01),
                    new ItemLoot("Diamond", 0.75)
                )
            )
        ;
    }
}