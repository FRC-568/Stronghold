using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHold
{
    class Bot
    {
        public double maxSpeed { get; set; } //
        public enum Alliance { red,blue}
        public Alliance team;
        public fieldLocation location= new fieldLocation();
        public Boolean canShoot;
        public Boolean canBreach;
        public Boolean canClimb;
        public Boolean hasBall;
        [Flags] public enum autoAbility { none=0, move=1, breach=2, shoot=4 }
        [Flags] public enum teleAbility {none=0, shoot=1, climb=2, breach=4,shootLow=8}
        public enum botMode {  none,auto,tele}
        public botMode mode;
        public autoAbility canAuto;
        //for next action
        IBotStrategy strategy;
        public double distancetogo;
        fieldLocation.places destination;
        public Defense def;
        public double defenseTimetogo;

        public GameField field;

        public Bot(teleAbility kind, autoAbility autoKind, Alliance side)
        {
            canShoot = kind.HasFlag(teleAbility.shoot);
            canClimb = kind.HasFlag(teleAbility.climb);
            canBreach = kind.HasFlag(teleAbility.breach);

            canAuto = autoKind;
            hasBall = true; //let each robot start with a ball
            mode = botMode.none;

            strategy = new BotStrategy(this);
            //strategy = new BotAllen(this);

            location.current = fieldLocation.places.neutral;
            destination = fieldLocation.places.not_set;
            distancetogo = 0;
            team = side;
            maxSpeed = 5.0; //default to 5 fps
        }
        //bot actions
        //shooter pattern: 
        //  from passage receive ball, 
        //  move to neutral, 
        //  move to X outerworks,
        //  move to courtyard
        //  high shooter:
        //      move to position
        //      shoot
        //  low shooter:
        //      move to batter
        //      score
        //      move to courtyaard
        //  move to outerworks
        //  move to neutral
        //  move to passage

        public void runAuto(double timeincr)
        {
            mode = botMode.auto;
            if (canAuto == autoAbility.none) return; //sits in auto
            if (distancetogo > 0)
            {
                distancetogo -= maxSpeed * timeincr; 
                return; //currently driving
            }
            if (def != null)
            {
                //currently trying to breach a defense
                //has time elapsed?
                defenseTimetogo -= timeincr;
                if (defenseTimetogo < 0)
                {
                    if (def.attempt())
                    {
                        //success!
                        field.autoScore += 10;
                        def = null;
                    }
                    else
                    {
                        //fail, try again
                        defenseTimetogo = def.friction;
                    }
                }
            }
            else
            {
                destination = strategy.NextLocation(destination);
            }
 
        }
        public void run(double timeincr)
        {
            //given a time increment do what we can
            //where do we want to go?
            mode = botMode.tele;
            if (distancetogo > 0)
            {
                distancetogo -= maxSpeed * timeincr;
                return; //currently driving
            }
            if (def != null)
            {
                //currently trying to breach a defense
                //has time elapsed?
                defenseTimetogo -= timeincr;
                if (defenseTimetogo < 0)
                {
                    if (def.attempt())
                    {
                        //success!
                        field.teleScore += 5;
                        def = null;
                    }
                    else
                    {
                        //fail, try again
                        defenseTimetogo = def.friction;
                    }
                }
            }
            else
            {
                destination = strategy.NextLocation(destination);
            }
        }
    }

}
