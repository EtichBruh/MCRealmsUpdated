namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ PolarBear = () => Behav()
        .Init("Polar Bear Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Polar Bear", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Polar Bear", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Polar Bear",
            new State(
                new ScaleHP(5000, 0),
                new State("first",
                    new Wander(1),
                    new Shoot(25, count: 3, shootAngle: 10, projectileIndex: 0, coolDown: 1500),
                    new Shoot(25, count: 16, shootAngle: 22.5, projectileIndex: 0, coolDown: 2500)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Tooth of a Polar Bear", 0.035),
                    new ItemLoot("Foot of a Foe", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Gold Ingot", 0.55),
                    new ItemLoot("Iron Ingot", 0.45)
                )
            )
        ;
    }
}
