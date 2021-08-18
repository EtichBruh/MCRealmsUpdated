namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Bee = () => Behav()
        .Init("Bee Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Bee", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Bee", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Bee",
            new State(
                new ScaleHP(12500, 0),
                new State("first",
                    new Taunt("Ya like jazz?"),
                    new Wander(0.25),
                    new Shoot(25, count: 8, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                    new Shoot(25, count: 16, fixedAngle: 0, shootAngle: 15, projectileIndex: 0, coolDown: 125, rotateAngle: 15),
                    new Shoot(25, count: 16, fixedAngle: 180, shootAngle: 15, projectileIndex: 0, coolDown: 125, rotateAngle: 15)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("ya like jazz", 0.01),
                    new ItemLoot("Bee Antenas", 0.009),
                    new ItemLoot("Bee Scythe", 0.01)
                )
            )
        ;
    }
}
