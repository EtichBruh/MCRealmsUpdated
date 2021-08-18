using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Allah = () => Behav()
        .Init("MC Allah",
            new State(
			    new ScaleHP(1000000, 0),						
                new State("first",
                    new Wander(0.9),
                    new Shoot(50, count: 4, projectileIndex: 0, shootAngle: 15, coolDown: 1500, coolDownOffset: 500),
                    new Shoot(50, count: 8, projectileIndex: 0, shootAngle: 20, coolDown: 3500, coolDownOffset: 1250)
                    )
            ),
            new Threshold(0.001,
                    new ItemLoot("Bin Laden's Ak-47", 0.009),
                    new ItemLoot("Bin Laden's Bomb", 0.01),
                    new ItemLoot("Golden Apple", 1),
                    new ItemLoot("Emerald x 10", 1),
                    new ItemLoot("Diamond x 10", 1)
                )
            )
        ;
    }
}