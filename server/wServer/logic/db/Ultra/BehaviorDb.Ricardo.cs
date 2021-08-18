namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Ricardo = () => Behav()
        .Init("Ricardo Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Ricardo", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Ricardo", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Ricardo",
            new State(
                new ScaleHP(1000000, 0),
                new State("first",
                    new Follow(2, 100, range: 0),
                    new Shoot(50, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 250)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Ricardo's Cock of Death", 0.0075),
                    new ItemLoot("Ricardo's Speedo", 0.0075),
                    new ItemLoot("Ricardo's Magical Cum", 0.025)
                )
            )
        ;
    }
}
