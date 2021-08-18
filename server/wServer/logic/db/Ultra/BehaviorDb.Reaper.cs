namespace wServer.logic
{
    using common.resources;
    using wServer.logic.behaviors;
    using wServer.logic.loot;
    using wServer.logic.transitions;

    partial class BehaviorDb
    {
        private _ Reaper = () => Behav()
        .Init("Reaper Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC REAPER OF DEATH MOTHERFUCKER", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC REAPER OF DEATH MOTHERFUCKER", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC REAPER OF DEATH MOTHERFUCKER",
            new State(
                new ScaleHP(500000, 0),
                new State("first",
                    new Follow(3, acquireRange: 100, range: 0),
                    new Shoot(25, count: 12, fixedAngle: 0, shootAngle: 30, projectileIndex: 0, coolDown: 500, rotateAngle: 15),
                    new Shoot(25, count: 16, fixedAngle: 180, shootAngle: 22.5, projectileIndex: 1, coolDown: 1250, rotateAngle: 15)
               )
            ),
            new Threshold(0.001,
                    new ItemLoot("fake scythe of doom nigga", 0.008),
                    new ItemLoot("Bedrock", 0.009),
                    new ItemLoot("Reaper's Hood", 0.008)
                )
            )
        ;
    }
}
