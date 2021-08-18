using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Gay = () => Behav()
        .Init("Gay Monster Spawner",
            new State(
                new State("first",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntityNotExistsTransition("MC Gay", 999, "db")
                    ),
                new State("db",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(12500, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("MC Gay", 1, coolDown: 100),
                    new TimedTransition(500, "first")
                    )
                )
            )
        .Init("MC Gay",
            new State(
                new ScaleHP(30000, 0),
                new State("first",
                    new Shoot(30, count: 8, projectileIndex: 0, shootAngle: 10, coolDown: 700),
                    new Shoot(30, count: 5, projectileIndex: 0, rotateAngle: 2, fixedAngle: 2, coolDown: 100)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Lucky Block Shard x 1", 0.009),
                    new ItemLoot("Emerald", 0.05),
                    new ItemLoot("LGBTQ Chestplate", 0.009),
                    new ItemLoot("LGBTQ Sword", 0.009),
                    new ItemLoot("LGBTQ Bow", 0.009),
                    new ItemLoot("LGBTQ Axe", 0.009),
                    new ItemLoot("LGBTQ Staff", 0.009),
                    new ItemLoot("LGBTQ Wand", 0.009),
                    new ItemLoot("LGBTQ Pickaxe", 0.009),
                    new ItemLoot("LGBTQ Ring", 0.009),
                    new ItemLoot("Water Bucket", 0.009)
                )
            )
        ;
    }
}