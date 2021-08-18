namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Fazbear = () => Behav()
        .Init("Fazbear Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Fazzzybearrr", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Fazzzybearrr", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Fazzzybearrr",
            new State(
                new ScaleHP(750000, 0),
                new State("first",
                    new Wander(1.1),
                    new Shoot(59, count: 24, shootAngle: 2, projectileIndex: 0, coolDown: 2500, coolDownOffset: 750),
                    new Shoot(59, count: 16, shootAngle: 4, projectileIndex: 1, coolDown: 2500, coolDownOffset: 1250)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Freddy's Bras", 0.01),
                    new ItemLoot("Chica's Panties", 0.009),
                    new ItemLoot("Sexy Dress of Bonnie", 0.008),
                    new ItemLoot("so Bad Ring of Fuckers", 0.007)
                )
            )
        ;
    }
}
