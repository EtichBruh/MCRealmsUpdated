namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ King = () => Behav()
        .Init("King Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC King", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC King", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC King",
            new State(
                new ScaleHP(150000, 0),
                new State("first",
                    new Shoot(25, count: 8, fixedAngle: 8, rotateAngle: 8, projectileIndex: 0, coolDown: 125),
                    new TimedTransition(5000, "second")
                    ),
                new State("second",
                    new Follow(1, 50, 0),
                    new Shoot(25, count: 20, shootAngle: 10, projectileIndex: 1, coolDown: 2000),
                    new TimedTransition(5000, "first")
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Royal Sword", 0.009),
                    new ItemLoot("Royal Armor", 0.009)
                )
            )
        ;
    }
}
