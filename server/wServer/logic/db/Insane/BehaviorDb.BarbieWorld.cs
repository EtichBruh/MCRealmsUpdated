namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ BarbieWorld = () => Behav()
        #region Spawners
        .Init("BarbieBitch1 Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Barbie Bitch1", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Barbie Bitch1", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("BarbieBitch2 Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Barbie Bitch2", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Barbie Bitch2", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        #endregion

        .Init("MC Barbie Bitch1",
            new State(
                new ScaleHP(500000, 0),
                new State("first",
                    new Wander(0.5),
                    new Shoot(59, count: 24, shootAngle: 7, projectileIndex: 0, coolDown: 2000, coolDownOffset: 500),
                    new Shoot(59, count: 16, shootAngle: 14, projectileIndex: 1, coolDown: 2000, coolDownOffset: 1250),
                    new Shoot(59, count: 4, shootAngle: 20, projectileIndex: 2, coolDown: 2000, coolDownOffset: 2000)

               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Pink Wool", 0.009),
                    new ItemLoot("A pink toy", 0.008)
                )
        )

        .Init("MC Barbie Bitch2",
            new State(
                new ScaleHP(500000, 0),
                new State("first",
                    new Wander(0.5),
                    new Shoot(59, count: 24, shootAngle: 7, projectileIndex: 0, coolDown: 2000, coolDownOffset: 500),
                    new Shoot(59, count: 16, shootAngle: 14, projectileIndex: 1, coolDown: 2000, coolDownOffset: 1250),
                    new Shoot(59, count: 4, shootAngle: 20, projectileIndex: 2, coolDown: 2000, coolDownOffset: 2000)

               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Pink Wool", 0.009),
                    new ItemLoot("BARBIES FUCKING DOLL OF GRACE", 0.008)
                )
            )
        ;
    }
}
