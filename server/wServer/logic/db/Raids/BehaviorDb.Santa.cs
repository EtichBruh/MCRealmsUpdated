using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Santa = () => Behav()
        .Init("MC Santa",
            new State(
			    new ScaleHP(2500000, 0),						
                new State("1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("Ho Ho Ho Ho Ho"),
                    new TimedTransition(1250, "2")
                 ),
                new State("2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("Merry Christmas"),
                    new TimedTransition(1250, "3")
                 ),
                new State("3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("Have you been a good boy?"),
                    new TimedTransition(1250, "4")
                 ),
                new State("4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("I know you have!"),
                    new TimedTransition(1250, "5")
                 ),
                new State("5",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("Cum here, santa's got a suprise!"),
                    new PlayerWithinTransition(3, "fight")
                    ),
                new State("fight",
                    new SetAltTexture(1),
                    new Shoot(50, 90, shootAngle: 4, projectileIndex: 0, coolDown: 5000),
                    new Shoot(50, 10, shootAngle: 10, projectileIndex: 1, coolDown: 1500)
                )
            ),
            new Threshold(0.001,
                    new ItemLoot("Scepter of Santa", 0.0075),
                    new ItemLoot("Robe of Santa", 0.0075)
                )
            )
        ;
    }
}