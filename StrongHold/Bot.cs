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
        Boolean canShoot;
        Boolean canBreach;
        Boolean canClimb;
        [Flags] public enum autoAbility { none=0, move=1, breach=2, shoot=4 }
        [Flags] public enum teleAbility {none=0, shoot=1, climb=2, breach=4,shootLow=8}
        public autoAbility canAuto;
        //for next action
        double distancetogo;
        fieldLocation.places destination;
        Defense def;

        public GameField field;

        public Bot(teleAbility kind, autoAbility autoKind, Alliance side)
        {
            canShoot = kind.HasFlag(teleAbility.shoot);
            canClimb = kind.HasFlag(teleAbility.climb);
            canBreach = kind.HasFlag(teleAbility.breach);

            canAuto = autoKind;

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
            if (canAuto == autoAbility.none) return; //sits in auto
            if (distancetogo > 0)
            {
                distancetogo -= maxSpeed * timeincr; 
                return; //currently driving
            }
            if (def!=null)
            {
                //currently trying to breach a defense
            }
            switch (destination)
            {
                case fieldLocation.places.not_set:
                    if (team == Alliance.blue)
                        destination = fieldLocation.places.red_outerworks;
                    else
                        destination = fieldLocation.places.blue_outerworks;
                    distancetogo = WorldFacts.neutralToOuter;
                    break;
                case fieldLocation.places.blue_outerworks:
                    if (canAuto.HasFlag(autoAbility.breach))
                    {
                        //pick defense to breach
                        def = field.blueOuterworks[3];
                    }
                    break;

            }
 
        }
        public void run(double timeincr)
        {
            //given a time increment do what we can
            //where do we want to go?
        }
    }

}
