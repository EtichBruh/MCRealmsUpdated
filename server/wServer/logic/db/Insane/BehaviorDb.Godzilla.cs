namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Godzilla = () => Behav()
        .Init("Godzilla Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Godzilla", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Godzilla", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Godzilla",
            new State(
                new ScaleHP(50000, 0),
                new State("first",
                    new Follow(0.35, range: 0),
                    new Shoot(59, count: 15, shootAngle: 3, projectileIndex: 0, coolDown: 250),
                    new Shoot(59, count: 5, shootAngle: 10, projectileIndex: 0, coolDown: 2000)

               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Godzilla's Tail", 0.009),
                    new ItemLoot("NIGGA SCALES", 0.01)
                )
            )
        ;
    }
}
