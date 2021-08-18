using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Enderman = () => Behav()
        .Init("Enderman Monster Spawner",
            new State(			
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Enderman", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Enderman", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Enderman",
            new State(
			    new ScaleHP(12500, 0),						
                new State("first",
                    new Shoot(30, count: 12, projectileIndex: 0, rotateAngle: 3, fixedAngle: 3, coolDown: 150)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Minecraft Depression Block", 0.01),
                    new ItemLoot("ENDERMANS LONG FAT COCK", 0.009),
                    new ItemLoot("Enderman Head", 0.01)
                )
            )
        ;
    }
}