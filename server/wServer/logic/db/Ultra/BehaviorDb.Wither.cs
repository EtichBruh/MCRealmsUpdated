using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Wither = () => Behav()
        #region Wither Checker
        .Init("Wither Monster Checker",
            new State(
                new State("seconddb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Wither Statue 0"),
                    new TimedTransition(500, "first")
                    ),
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Wither Statue 0", 999, "seconddb")
                    ),
                new State("seconddb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Wither Statue 1"),
                    new TimedTransition(250, "second")
                    ),
                new State("second",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Wither Statue 1", 999, "thirddb")
                    ),
                new State("thirddb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Wither Statue 2"),
                    new TimedTransition(250, "third")
                    ),
                new State("third",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Wither Statue 2", 999, "fourthdb")
                    ),
                new State("fourthdb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Wither Statue 3"),
                    new TimedTransition(600, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new RemoveEntity(999, "Wither Statue 3"),
                    new Spawn("Wither Boss", 1, coolDown: 100),
                    new TimedTransition(1000, "check")
                    ),
                new State("check",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Wither Boss", 999, "spawn2")
                    ),
                new State("spawn2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Wither Statue 0", 1, coolDown: 100),
                    new TimedTransition(250, "first")
                    )
                )
            )
        #endregion
        .Init("Wither Boss",
            new State(
                new State("grow",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ChangeSize(1, 60),
                    new TimedTransition(4000, "first")
                    ),
                new State("first",
                    new Wander(1.2),
                    new SetAltTexture(1),
                    new Shoot(30, count: 3, projectileIndex: 0, shootAngle: 15, coolDown: 150),
                    new HpLessTransition(0.35, "rage")
                    ),
                new State("rage",
                    new Follow(1.2, 50, 0),
                    new SetAltTexture(0),
                    new Shoot(30, count: 3, projectileIndex: 1, shootAngle: 15, coolDown: 150)
                    )
                ),
               new Threshold(0.001,
                    new ItemLoot("Nether Star", 0.009),
                    new ItemLoot("THE UPGRADED VERSION OF THE WITHER CHESTPLATE FAGGOT", 0.009),
                    new ItemLoot("Golden Apple", 1)
                )
            )
        .Init("Wither Statue 0",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    )
                )
            )
        .Init("Wither Statue 1",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    )
                )
            )
        .Init("Wither Statue 2",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    )
                )
            )
        .Init("Wither Statue 3",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    )
                )
            )
        ;
    }
}