using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Cave = () => Behav()
        #region Ores

        .Init("Stone Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Stone", 1, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(1500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Stone", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Stone",
            new State(
                new State("first"
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Cobblestone", 1)
                )
            )

        #endregion
        #region Spawners
         .Init("Creeper Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Creeper", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Creeper", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
         .Init("Spider Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Spider", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Spider", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
         .Init("Zombie Monster Spawner",
            new State(
                new ScaleHP(6000, 0),
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Zombie", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Zombie", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
         .Init("Skeleton Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Skeleton", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Skeleton", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        #endregion

        .Init("MC Creeper",
            new State(
                new ScaleHP(6000, 0),
                new State("first",
                    new Follow(1.2, range: 0, coolDown: 0),
                    new Shoot(30, count: 5, projectileIndex: 0, shootAngle: 15, coolDown: 1500, coolDownOffset: 900),
                    new Shoot(30, count: 12, projectileIndex: 0, shootAngle: 36, coolDown: 1500, coolDownOffset: 1250)
                )
            ),
            new Threshold(1,
                    new ItemLoot("Emerald", 0.05)
                )
            )

        .Init("MC Skeleton",
            new State(
                new ScaleHP(6000, 0),
                new State("first",
                    new Follow(1.2, range: 0, coolDown: 0),
                    new Shoot(30, count: 8, projectileIndex: 0, shootAngle: 10, coolDown: 1500, coolDownOffset: 900),
                    new Shoot(30, count: 1, projectileIndex: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1250)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Skeleton Head", 0.03),
                    new ItemLoot("Bone", 1)
                )
            )

        .Init("MC Spider",
            new State(
                new ScaleHP(6000, 0),
                new State("first",
                    new Follow(1.2, range: 0, coolDown: 0),
                    new Shoot(30, count: 12, projectileIndex: 0, shootAngle: 36, coolDown: 250)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("String", 1)
                )
            )
        .Init("MC Zombie",
            new State(
                new State("first",
                    new Follow(1.2, range: 0, coolDown: 0),
                    new Shoot(30, count: 5, projectileIndex: 0, shootAngle: 12, coolDown: 1000, coolDownOffset: 700)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Zombie Head", 0.03)
                )
            )
        ;
    }
}