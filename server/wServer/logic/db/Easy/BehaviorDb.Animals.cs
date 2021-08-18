using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Animals = () => Behav()
        #region Spawners
        .Init("Wood Log Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Wood Log", 1, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(1500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Wood Log", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Cow Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Cow", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(3500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Cow", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
         .Init("Sheep Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Sheep", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(3500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Sheep", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("Pig Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Pig", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(3500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Pig", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
         .Init("Chicken Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Chicken", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(3500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Chicken", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        #endregion

        .Init("MC Wood Log",
            new State(
                new State("first"
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Wood Log", 1),
                    new ItemLoot("Stick", 0.35)
                )
            )

        .Init("MC Cow",
            new State(
                new State("first",
                    new Wander(0.5)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Leather", 0.5),
                    new ItemLoot("Raw Beef", 1),
                    new ItemLoot("Raw Beef", 0.8),
                    new ItemLoot("Raw Beef", 0.6),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05)
                )
            )

        .Init("MC Sheep",
            new State(
                new State("first",
                    new Wander(0.5)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Raw Mutton", 1),
                    new ItemLoot("Raw Mutton", 0.8),
                    new ItemLoot("Raw Mutton", 0.6),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05)
                )
            )

        .Init("MC Pig",
            new State(
                new State("first",
                    new Wander(0.5)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Raw Porkchop", 1),
                    new ItemLoot("Raw Porkchop", 0.8),
                    new ItemLoot("Raw Porkchop", 0.6),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05)
            )
            )

        .Init("MC Chicken",
            new State(
                new State("first",
                    new Wander(0.5)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Raw Chicken", 1),
                    new ItemLoot("Raw Chicken", 0.8),
                    new ItemLoot("Raw Chicken", 0.6),
                    new ItemLoot("Redstone", 0.65),
                    new ItemLoot("Lapis Lazuli", 0.35),
                    new ItemLoot("Gold Ingot", 0.15),
                    new ItemLoot("Iron Ingot", 0.05)
                )
            )
        ;
    }
}