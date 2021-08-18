#region

using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.logic.behaviors.PetBehaviors;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Misc = () => Behav()
            .Init("White Fountain",
                new State(
                    new HealPlayer(5, 100, 99999),
                    new HealPlayerMP(5, 100, 99999)
                )
            )
                .Init("Aether Portal Checker",
            new State(
                new State("seconddb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Aether Portal 1"),
                    new TimedTransition(500, "first")
                    ),
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Aether Portal 1", 999, "seconddb")
                    ),
                new State("seconddb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Aether Portal 2"),
                    new TimedTransition(250, "second")
                    ),
                new State("second",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Aether Portal 2", 999, "thirddb")
                    ),
                new State("thirddb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Aether Portal 3"),
                    new TimedTransition(250, "third")
                    ),
                new State("third",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Aether Portal 3", 999, "fourthdb")
                    ),
                new State("fourthdb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Aether Portal 4"),
                    new TimedTransition(600, "fith")
                  ),
                new State("fith",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Aether Portal 4", 999, "fithdb")
                    ),
                new State("fithdb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Aether Portal 5"),
                    new TimedTransition(600, "sixthdb")
                  ),
                new State("sixth",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Aether Portal 5", 999, "sixthdb")
                    ),
                new State("sixthdb",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Aether Portal 6"),
                    new TimedTransition(600, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new RemoveEntity(999, "Aether Portal 6"),
                    new Spawn("Aether Portal", 1, coolDown: 100),
                    new TimedTransition(1000, "check")
                    ),
                new State("check",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("Aether Portal", 999, "spawn2")
                    ),
                new State("spawn2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Aether Portal 1", 1, coolDown: 100),
                    new TimedTransition(250, "first")
                    )
                )
            )
        ;
    }
}