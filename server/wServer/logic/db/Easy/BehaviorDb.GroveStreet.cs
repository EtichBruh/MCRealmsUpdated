using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ GroveStreet = () => Behav()

        .Init("MC Ryder",
            new State(
                new ScaleHP(5000000, 0),
                new State("beforeScript",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new PlayerWithinTransition(5, "startMusic")
                    ),
                new State("startMusic",
                    new ChangeMusic("gangstarapnword"),
                    new TimedTransition(2000, "100 percent nigga")
                    ),
                new State("100 percent nigga",
                    new Taunt("I'm 100% nigga"),
                    new Order(10, "MC Big Smoke", "200 percent nigga"),
                    new TimedTransition(500, "wait1")
                    ),
                new State("wait1"),
                new State("swag",
                    new Taunt("LETS FUCK THEM BIG SMOKE"),
                    new Order(10, "MC Big Smoke", "kill"),
                    new TimedTransition(5000, "kill")
                    ),
                new State("kill",
                    new HpLessTransition(0.5, "kill2"),
                    new RemoveConditionalEffect(ConditionEffectIndex.Invincible),
                    new Shoot(30, predictive: 0.5, coolDown: new Cooldown(2000, 1000)),
                    new Wander(0.5)
                    ),
                new State("kill2",
                    new HpLessTransition(0.2, "kill3"),
                    new Shoot(30, predictive: 0.5, coolDown: new Cooldown(2000, 666)),
                    new Shoot(15, 5, fixedAngle: 0, rotateAngle: 15, coolDown: 1777),
                    new Wander(0.5)
                    ),
                new State("kill3",
                    new Taunt("IT'S TIME YOU DIE."),
                    new Shoot(30, predictive: 0.5, coolDown: new Cooldown(2000, 666)),
                    new Shoot(15, 5, fixedAngle: 0, rotateAngle: 15, coolDown: 1777),
                    new Wander(0.5)
                    )
                ),
            new Threshold(0.04,
                new ItemLoot("PPE Sword", 0.04),
                new ItemLoot("Haste IV Potion", 0.1),
                new ItemLoot("Instant Health IV Potion", 0.1),
                new ItemLoot("Speed IV Potion", 0.1),
                new ItemLoot("Strength Potion", 0.1),
                new ItemLoot("TRUE Strength Potion", 0.1),

                new ItemLoot("Golden Apple", 0.75),
                new ItemLoot("Golden Apple", 0.75),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999)
                )
            )

        .Init("MC Big Smoke",
            new State(
                new ScaleHP(5000000, 0),
                new State("beforeScript",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                new State("200 percent nigga",
                    new Taunt("I'm 200% nigga"),
                    new TimedTransition(5000, "wait a bit and kill them")
                    ),
                new State("wait a bit and kill them",
                    new Taunt("Y'all niggas about to die"),
                    new Order(10, "MC Ryder", "swag"),
                    new TimedTransition(500, "wait1")
                    ),
                new State("wait1"),
                new State("kill",
                    new HpLessTransition(0.5, "kill2"),
                    new RemoveConditionalEffect(ConditionEffectIndex.Invincible),
                    new Shoot(30, predictive: 0.5, coolDown: new Cooldown(2000, 1000)),
                    new Shoot(15, 5, fixedAngle: 0, rotateAngle: 15, coolDown: 2000),
                    new Wander(0.5)
                    ),
                new State("kill2",
                    new HpLessTransition(0.2, "kill3"),
                    new Shoot(30, predictive: 0.5, coolDown: new Cooldown(2000, 666)),
                    new Wander(0.5)
                    ),
                new State("kill3",
                    new Taunt("BRRRRRRRRRRRRRRRRRRRRRRRR DIE NIGGAZ"),
                    new Shoot(30, 2, shootAngle: 5, predictive: 0.5, coolDown: 222),
                    new ReturnToSpawn(2, 0)
                    )
                ),
            new Threshold(0.04,
                new ItemLoot("ThicKendo Stick", 0.04),
                new ItemLoot("Haste IV Potion", 0.1),
                new ItemLoot("Instant Health IV Potion", 0.1),
                new ItemLoot("Speed IV Potion", 0.1),
                new ItemLoot("Strength Potion", 0.1),
                new ItemLoot("TRUE Strength Potion", 0.1),

                new ItemLoot("Golden Apple", 0.75),
                new ItemLoot("Golden Apple", 0.75),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999),
                new ItemLoot("Emerald", 0.999)
                )
            )

        .Init("Gangsta Rap Chest",
            new State(
                new ScaleHP(25000, 0),
                new State("imADumbChest",
                    new Taunt("Have fun with your crap! Make sure to ask for the admins to not open this dungeon in the future.")
                    )
                ),
            new Threshold(0.02,
                new ItemLoot("True PPE Sword", 0.02),
                new ItemLoot("True ThicKendo Stick", 0.02),
                new ItemLoot("Draconis Potion", 0.01),
                new ItemLoot("Golden Apple", 0.75),
                new ItemLoot("Golden Apple", 0.75),
                new ItemLoot("Emerald", 0.999)
                )
            )

        ;
    }
}