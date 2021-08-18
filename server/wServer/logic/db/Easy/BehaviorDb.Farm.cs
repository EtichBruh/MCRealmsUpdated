using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Farm = () => Behav()
                .Init("Slave Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Slave", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Slave", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Slave",
            new State(
                new State("fight",
                    new Wander(0.5),
                    new Shoot(50, count: 12, projectileIndex: 0, shootAngle: 30, coolDown: 2500)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Oxwhip", 0.01),
                    new ItemLoot("Insert Blank Here Frost lol noob", 0.01)
                )
            )
        ;
    }
}