namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ IronGolem = () => Behav()
        .Init("Iron Golem Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Iron Golem", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Iron Golem", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Iron Golem",
            new State(
                new ScaleHP(8000, 0),
                new State("first",
                    new Follow(0.7, range: 0),
                    new Shoot(25, count: 4, shootAngle: 10, projectileIndex: 0, coolDown: 1250)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("Iron Ingot", 1),
                    new ItemLoot("Block of Iron", 0.1),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Redstone", 0.75),
                    new ItemLoot("Lapis Lazuli", 0.45),
                    new ItemLoot("Gold Ingot", 0.35),
                    new ItemLoot("Iron Ingot", 0.15)
                )
            )
        ;
    }
}
