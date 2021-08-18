using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Nether = () => Behav()
        #region Teleports
        .Init("TP Blaze 1",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(79, 121)
                        )
                    )
               )
        .Init("TP Blaze 2",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(106, 121)
                        )
                    )
               )
        .Init("TP Magma 1",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(114, 156)
                        )
                    )
               )
        .Init("TP Magma 2",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(114, 129)
                        )
                    )
               )
        .Init("TP Ghast 1",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(114, 86)
                        )
                    )
               )
        .Init("TP Ghast 2",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(114, 113)
                        )
                    )
               )
        .Init("TP Wither 1",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(149, 121)
                        )
                    )
               )
        .Init("TP Wither 2",
                new State(
                    new State("Teleport",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TeleportPlayer(122, 121)
                        )
                    )
               )
        #endregion
        #region Spawners
        .Init("Blaze Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Blaze", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Blaze", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Magma Cube Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Magma Cube", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Magma Cube", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Ghast Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Ghast", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Ghast", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Wither Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Wither Skeleton", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Wither Skeleton", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        #endregion
        .Init("MC Blaze",
            new State(
                new ScaleHP(25000, 0),
                new State("first",
                    new Wander(0.35),
                    new Shoot(50, count: 36, projectileIndex: 0, shootAngle: 10, coolDown: 5000, coolDownOffset: 3000),
                    new Shoot(50, count: 5, projectileIndex: 0, shootAngle: 8, coolDown: 5000, coolDownOffset: 4250)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Blaze Rod", 0.025),
                    new ItemLoot("Glowstone Dust", 0.5),
                    new ItemLoot("Blaze Powder", 0.025)
                    )
            )
        .Init("MC Magma Cube Minion",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Orbit(0.5, 5, 999, "MC Magma Cube")
                    ),
                new State("fight",
                    new Orbit(0.5, 5, 999, "MC Magma Cube"),
                    new Shoot(50, count: 5, projectileIndex: 0, shootAngle: 72, coolDown: 5000, coolDownOffset: 1750),
                    new Shoot(50, count: 5, projectileIndex: 0, shootAngle: 72, coolDown: 5000, coolDownOffset: 2500)
                    )
                )
            )
        .Init("MC Magma Cube",
            new State(
                new ScaleHP(25000, 0),
                new OnDeathBehavior(new RemoveEntity(999, "MC Magma Cube Minion")),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Magma Cube Minion", maxChildren: 1),
                    new TimedTransition(1000, "2")
                    ),
                new State("2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Magma Cube Minion", maxChildren: 1),
                    new TimedTransition(1000, "3")
                    ),
                new State("3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Magma Cube Minion", maxChildren: 1),
                    new TimedTransition(1000, "fight")
                    ),
                new State("fight",
                    new Spawn("MC Magma Cube Minion", maxChildren: 1),
                    new Order(999, "MC Magma Cube Minion", "fight"),
                    new StayCloseToSpawn(0.5, 10),
                    new Shoot(50, count: 8, projectileIndex: 0, shootAngle: 45, coolDown: 5000, coolDownOffset: 3500)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Magma Head", 0.01),
                    new ItemLoot("Glowstone Dust", 0.5),
                    new ItemLoot("Magma Armor", 0.025)
                )
            )
        .Init("MC Ghast",
            new State(
                new ScaleHP(25000, 0),
                new State("fight",
                    new Shoot(50, count: 3, projectileIndex: 0, fixedAngle: -9, rotateAngle: -9, coolDown: 150),
                    new Shoot(50, count: 3, projectileIndex: 0, fixedAngle: 9, rotateAngle: 9, coolDown: 150),
                    new Shoot(50, count: 4, projectileIndex: 1, shootAngle: 10, coolDown: 5000, coolDownOffset: 3500)

                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Glowstone Dust", 0.5),
                    new ItemLoot("Ghast Tear", 0.015)
                )
            )
        .Init("MC Wither Skeleton",
            new State(
                new ScaleHP(25000, 0),
                new State("fight",
                    new Follow(1.2, range: 0, coolDown: 0),
                    new Shoot(50, count: 1, projectileIndex: 0, fixedAngle: 9, rotateAngle: 9, coolDown: 200),
                    new Shoot(50, count: 2, projectileIndex: 0, shootAngle: 15, coolDown: 1500, coolDownOffset: 500),
                    new Shoot(50, count: 8, projectileIndex: 0, shootAngle: 45, coolDown: 1500, coolDownOffset: 1250)

                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Wither Skull", 0.25),
                    new ItemLoot("Glowstone Dust", 0.5),
                    new ItemLoot("Withered-Cobblestone", 0.015),
                    new ItemLoot("Wither Skeleton Plate", 0.009)
                )
            )
        ;
    }
}