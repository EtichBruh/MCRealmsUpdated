using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Slime = () => Behav()
                .Init("Slime Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Slime", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Slime", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Slime Minion",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Orbit(0.5, 10, 999, "MC Slime")
                    ),
                new State("fight",
                    new Orbit(0.5, 10, 999, "MC Slime"),
                    new Shoot(50, count: 4, projectileIndex: 0, fixedAngle: 6, rotateAngle: 6, coolDown: 125)
                    )
                )
            )
        .Init("MC Slime",
            new State(
                new OnDeathBehavior(new RemoveEntity(999, "MC Slime Minion")),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Slime Minion", maxChildren: 1),
                    new TimedTransition(1000, "2")
                    ),
                new State("2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Slime Minion", maxChildren: 1),
                    new TimedTransition(1000, "3")
                    ),
                new State("3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Slime Minion", maxChildren: 1),
                    new TimedTransition(1000, "fight")
                    ),
                new State("fight",
                    new Spawn("MC Slime Minion", maxChildren: 1),
                    new Order(999, "MC Slime Minion", "fight"),
                    new StayCloseToSpawn(0.5, 10),
                    new Shoot(50, count: 8, projectileIndex: 0, shootAngle: 45, coolDown: 3000, coolDownOffset: 1500)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("Slime Boots", 0.015),
                    new ItemLoot("Slime Ball", 1),
                    new ItemLoot("Enchanted Slime Ball", 0.035),
                    new ItemLoot("Gold Ingot", 0.55),
                    new ItemLoot("Iron Ingot", 0.45),
                    new ItemLoot("Diamond", 0.15)
                )
            )
        ;
    }
}