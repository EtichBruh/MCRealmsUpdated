using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Mineshaft = () => Behav()
        .Init("Miner Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Miner", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Miner", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Miner",
            new State(
                new ScaleHP(8000, 0),
                new State("first",
                    new Shoot(50, count: 48, projectileIndex: 0, shootAngle: 7.5, coolDown: 3000),
                    new Shoot(50, count: 16, projectileIndex: 0, shootAngle: 10, coolDown: 1500)
                    )
            ),
            new Threshold(0.001,
			        new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Block of Obsidian", 0.15),
                    new ItemLoot("Miners Helmet", 0.025),
                    new ItemLoot("Gold Ingot", 0.55),
                    new ItemLoot("Iron Ingot", 0.45),
                    new ItemLoot("Diamond", 0.15)
                )
            )
        ;
    }
}