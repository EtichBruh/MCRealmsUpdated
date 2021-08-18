using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Wish = () => Behav()
                .Init("Wish Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Wish", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Wish", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Wish",
            new State(
                new State("fight",
                    new Wander(0.5),
                    new Shoot(50, count: 8, projectileIndex: 0, shootAngle: 45, coolDown: 1500)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Wish's Black Paint", 0.01),
                    new ItemLoot("Wish's Cum", 0.01)
                )
            )
        ;
    }
}