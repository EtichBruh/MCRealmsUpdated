namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Frank = () => Behav()
        .Init("Frank Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Frankster", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Frankster", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Frankster",
            new State(
                new ScaleHP(250000, 0),
                new State("first",
                    new Wander(2.5),
                    new Shoot(25, count: 36, fixedAngle: 10, projectileIndex: 0, coolDown: 2500, rotateAngle: 10)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("FRANK'S DIRTY ASS AIRPODS GEN 3", 0.0075),
                    new ItemLoot("FRANK'S ASSHOLE OF DOOM", 0.0075),
                    new ItemLoot("FRANK'S discord login info", 0.0075),
                    new ItemLoot("FRANK'S gay xbox", 0.0075)
                )
            )
        ;
    }
}
