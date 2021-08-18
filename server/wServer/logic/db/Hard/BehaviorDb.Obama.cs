using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Obama = () => Behav()
        .Init("Obama Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Obama", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Obama", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Obama",
            new State(
			    new ScaleHP(70000, 0),			
                new State("first",
                    new Wander(0.5),
                    new Shoot(50, count: 4, projectileIndex: 0, shootAngle: 15, coolDown: 1700),
                    new Shoot(50, count: 8, fixedAngle: 7, rotateAngle: 7, coolDown: 500)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("OBAMA'S LAST NAME", 0.009),
                    new ItemLoot("Tuxedo of Obama", 0.009),
                    new ItemLoot("N-word pass", 0.009),
                    new ItemLoot("america flag", 0.009)
                )
            )
        ;
    }
}