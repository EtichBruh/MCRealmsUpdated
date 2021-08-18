using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ WitherStorm = () => Behav()
        .Init("MC Wither Storm",
            new State(
                new ScaleHP(500000, 0),
                new State("first",
                    new Wander(0.5),
                    new Shoot(50, count: 16, projectileIndex: 0, rotateAngle: 10, fixedAngle: 10, coolDown: 1500),
                    new Shoot(50, count: 16, projectileIndex: 1, rotateAngle: 15, fixedAngle: 15, coolDown: 2000)
                    )
            ),
            new Threshold(0.1,
                    new ItemLoot("WITHERING BOW OMG SHIT", 0.009),
                    new ItemLoot("THICC WITHER PICKAXE", 0.009),
                    new ItemLoot("not slasher dumbass bitch withering wand op", 0.009),
                    new ItemLoot("Command Block", 0.008),
                    new ItemLoot("Golden Apple", 1)
                )
            )
        ;
    }
}