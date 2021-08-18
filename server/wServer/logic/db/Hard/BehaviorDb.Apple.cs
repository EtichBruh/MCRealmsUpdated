using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Apple = () => Behav()
        .Init("Steve Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Steve Jobs", 400, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Steve Jobs", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Steve Jobs",
            new State(
			    new ScaleHP(150000, 0),			
                new State("first",
                    new Wander(0.5),
                    new Shoot(50, count: 12, projectileIndex: 0, shootAngle: 30, coolDown: 1700),
                    new Shoot(50, count: 4, fixedAngle: 7, rotateAngle: 7, coolDown: 500)
                    )
            ),
            new Threshold(0.5,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("I-Pen", 0.01),
                    new ItemLoot("I-Bow", 0.01),
                    new ItemLoot("Airpods", 0.009),
                    new ItemLoot("I9's TWS", 0.01),
                    new ItemLoot("Frank's Dirty Ass Airpods", 0.015)
                )
            )
        ;
    }
}