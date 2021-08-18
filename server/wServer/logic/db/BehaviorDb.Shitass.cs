namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Shitass = () => Behav()
        .Init("Shitass Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Shitass", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Shitass", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Shitass",
            new State(
                new ScaleHP(10000000, 0),
                new State("first",
                    new Wander(3),
                    new Shoot(100, count: 50, shootAngle: 7.2, projectileIndex: 0, coolDown: 3500),
                    new Shoot(100, count: 8, shootAngle: 7.2, projectileIndex: 1, coolDown: 1500)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Shitass's Head", 0.009)
                )
            )
        ;
    }
}
