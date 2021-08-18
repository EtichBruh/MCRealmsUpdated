using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Village = () => Behav()
        #region Spawners
        .Init("Toolsmith Villager Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Toolsmith Villager", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Toolsmith Villager", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Weaponsmith Villager Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Weaponsmith Villager", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Weaponsmith Villager", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Mason Villager Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Mason Villager", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Mason Villager", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Armorer Villager Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Armorer Villager", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Armorer Villager", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        #endregion

        .Init("MC Toolsmith Villager",
            new State(
                new ScaleHP(12500, 0),
                new State("first",
                    new Wander(0.35),
                    new Shoot(30, count: 40, projectileIndex: 0, shootAngle: 9, coolDown: 600)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.1),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05)
                )
            )

        .Init("MC Weaponsmith Villager",
            new State(
                new ScaleHP(12500, 0),
                new State("first",
                    new Wander(0.35),
                    new Shoot(30, count: 40, projectileIndex: 0, shootAngle: 9, coolDown: 600)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.1),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05)
                )
            )

        .Init("MC Mason Villager",
            new State(
                new ScaleHP(12500, 0),
                new State("first",
                    new Wander(0.35),
                    new Shoot(30, count: 40, projectileIndex: 0, shootAngle: 9, coolDown: 600)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.1),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05),
                    new ItemLoot("Villager's Emerald Bow", 0.01)
                )
            )

        .Init("MC Armorer Villager",
            new State(
                new ScaleHP(12500, 0),
                new State("first",
                    new Wander(0.35),
                    new Shoot(30, count: 40, projectileIndex: 0, shootAngle: 9, coolDown: 600)
                )
            ),
            new Threshold(0.01,
                    new ItemLoot("Emerald", 0.1),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05)
                )
            )
        ;
    }
}