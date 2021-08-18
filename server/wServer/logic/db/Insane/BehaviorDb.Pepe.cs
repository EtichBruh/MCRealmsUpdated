namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Pepe = () => Behav()
        .Init("PEPE Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC PEPE", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC PEPE", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC PEPE",
            new State(
                new ScaleHP(750000, 0),
                new State("first",
                    new Shoot(59, count: 8, rotateAngle: 5, fixedAngle: 5, projectileIndex: 0, coolDown: 115),
                    new Shoot(59, count: 5, shootAngle: 18, projectileIndex: 1, coolDown: 5000)
               )
            ),
            new Threshold(0.1,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Pepe's Head", 0.008)
                )
            )
        ;
    }
}
