using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Witch = () => Behav()
        .Init("Witch Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Witch", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Witch", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Witch",
            new State(
			    new ScaleHP(10000, 0),			
                new State("first",
                    new Grenade(8, 50, range: 12, coolDown: 1250, effect: ConditionEffectIndex.Slowed, effectDuration: 500),
                    new Grenade(8, 80, range: 12, coolDown: 2500, effect: ConditionEffectIndex.ArmorBroken, effectDuration: 500)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Witches Hat", 0.025),
                    new ItemLoot("Witches Powerful Potion", 0.009),			
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Diamond", 0.75)
                )
            )
        ;
    }
}