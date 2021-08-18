namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Pacman = () => Behav()
        .Init("Pacman Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Pac-Man", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Pac-Man", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Pac-Man",
            new State(
                new ScaleHP(150000, 0),
                new State("first",
                    new Follow(1.5, range: 0, acquireRange: 999),
                    new Shoot(59, count: 12, shootAngle: 4, projectileIndex: 2, coolDown: 250),
                    new Shoot(59, count: 16, shootAngle: 8, projectileIndex: 0, coolDown: 500),
                    new Shoot(59, count: 1, projectileIndex: 1, coolDown: 1250)

               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Cheese Block", 0.01),
                    new ItemLoot("Pac-Man's Boxing Glove", 0.009)
                )
            )
        ;
    }
}
