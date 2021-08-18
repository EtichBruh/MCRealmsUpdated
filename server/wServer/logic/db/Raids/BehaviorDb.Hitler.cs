using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Hitler = () => Behav()
        .Init("MC Hitler",
            new State(
			    new ScaleHP(2000000, 0),				
                new State("first",
                    new Wander(0.9),
                    new Shoot(50, count: 4, projectileIndex: 0, shootAngle: 10, coolDown: 1000, coolDownOffset: 350),
                    new Shoot(50, count: 16, projectileIndex: 0, shootAngle: 22.5, coolDown: 1000, coolDownOffset: 800)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Ray Gun", 0.008),
                    new ItemLoot("MP-40", 0.01),
                    new ItemLoot("Luger", 0.01),
                    new ItemLoot("Emerald x 10", 1),
                    new ItemLoot("Emerald x 10", 1)
                )
            )
        ;
    }
}