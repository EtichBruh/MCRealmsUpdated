using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Thanos = () => Behav()
        .Init("MC Thanos",
            new State(
                new ScaleHP(1250000, 0),
                new State("first",
                    new Wander(0.5),
                    new Shoot(50, count: 5, projectileIndex: 0, shootAngle: 8,  coolDown: 16000, coolDownOffset: 2000),
                    new Shoot(50, count: 10, projectileIndex: 1, shootAngle: 8, coolDown: 16000, coolDownOffset: 4000),
                    new Shoot(50, count: 5, projectileIndex: 2, shootAngle: 8, coolDown: 16000, coolDownOffset: 6000),
                    new Shoot(50, count: 10, projectileIndex: 3, shootAngle: 8, coolDown: 16000, coolDownOffset: 8000),
                    new Shoot(50, count: 5, projectileIndex: 4, shootAngle: 8, coolDown: 16000, coolDownOffset: 10000),
                    new Shoot(50, count: 10, projectileIndex: 5, shootAngle: 8, coolDown: 16000, coolDownOffset: 12000),
                    new Shoot(50, count: 40, projectileIndex: 5, shootAngle: 9, coolDown: 16000, coolDownOffset: 14000)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Infinity Gauntlet", 0.007),
                    new ItemLoot("Golden Apple", 1)
                )
            )
        ;
    }
}