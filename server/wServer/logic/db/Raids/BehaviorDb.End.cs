using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ End = () => Behav()
        .Init("MC Obsidian Pillar",
            new State(
                new ScaleHP(500000, 0),
                new State("first",
                    new HealEntity(999, "MC Ender Dragon", 1000, 1000),
                    new Shoot(50, count: 1, projectileIndex: 0, coolDown: 3250)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Emerald x 1", 0.25),
                    new ItemLoot("Diamond x 1", 0.1)
                )
            )
        .Init("MC Ender Dragon",
            new State(
                new ScaleHP(1000000, 0),
                new State("first",
                    new Orbit(1.75, 12, 999, "Ender Dragon Monster Spawner"),
                    new Shoot(50, count: 4, projectileIndex: 1, shootAngle: 20, coolDown: 5000, coolDownOffset: 2200),
                    new Shoot(50, count: 2, projectileIndex: 0, shootAngle: 20, coolDown: 5000, coolDownOffset: 3500),
                    new EntityNotExistsTransition("MC Obsidian Pillar", 999, "fight")
                    ),
                new State("fight",
                    new ReturnToSpawn(1.5),
                    new Wander(1),
                    new Shoot(50, count: 10, projectileIndex: 1, shootAngle: 36, coolDown: 5000, coolDownOffset: 2200),
                    new Shoot(50, count: 3, projectileIndex: 0, shootAngle: 120, coolDown: 5000, coolDownOffset: 3500),
                    new TimedTransition(18000, "wait")
                    ),
                new State("wait",
                    new ReturnToSpawn(1),
                    new ConditionalEffect(ConditionEffectIndex.Invincible, duration: 1000),
                    new InvisiToss("MC Obsidian Pillar", 15, -45, 99999),
                    new InvisiToss("MC Obsidian Pillar", 15, 0, 99999),
                    new InvisiToss("MC Obsidian Pillar", 15, 45, 99999),
                    new InvisiToss("MC Obsidian Pillar", 15, 135, 99999),
                    new InvisiToss("MC Obsidian Pillar", 15, 180, 99999),
                    new InvisiToss("MC Obsidian Pillar", 15, 235, 99999),
                    new TimedTransition(1000, "first")
                    )
            ),
            new Threshold(0.0001,
                    new ItemLoot("Dragon's Potion", 0.025),
                    new ItemLoot("Ender Sword", 0.025),
                    new ItemLoot("Ender Bow", 0.025),
                    new ItemLoot("Ender Wand", 0.025),
                    new ItemLoot("Ender Axe", 0.025),
                    new ItemLoot("Ender Pickaxe", 0.025)
                )
            )
        ;
    }
}