using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHold
{
    class GameField
    {
        Tower redTower, blueTower;
        Bot[] redAlliance = new Bot[3];
        Bot[] blueAlliance = new Bot[3];
        public Defense[] redOuterworks = new Defense[5];
        public Defense[] blueOuterworks = new Defense[5];

        double gameTime;

        double autoScore;
        double teleScore;

        public GameField()
        {
            redTower = new Tower();
            blueTower = new Tower();
        }

        public void setup()
        {
            //setup defenses
            redOuterworks[0] = new Defense();
            //setup bots
            //make some shortcut lables
            Bot.teleAbility tele1 = Bot.teleAbility.shoot | Bot.teleAbility.climb;
            Bot.teleAbility tele2 = Bot.teleAbility.breach;
            Bot.autoAbility auto0 = Bot.autoAbility.none;
            Bot.autoAbility auto1 = Bot.autoAbility.breach;
            //build bots
            redAlliance[0] = new Bot(tele1, auto0,Bot.Alliance.red);
            redAlliance[1] = new Bot(tele1, auto0, Bot.Alliance.red);
            redAlliance[2] = new Bot(tele1, auto0, Bot.Alliance.red);
            blueAlliance[0] = new Bot(tele2,auto1, Bot.Alliance.blue);
            blueAlliance[1] = new Bot(tele2, auto1, Bot.Alliance.blue);
            blueAlliance[2] = new Bot(tele2, auto1, Bot.Alliance.blue);
            for (int i = 0; i < 3; i++) //tell all robots how to find the field
            {
                redAlliance[i].field = this;
                blueAlliance[i].field = this;
            }
        }

        public void run()
        {
            double incr = 0.1;
            //auto
            autoScore = 0;
            teleScore = 0;
            gameTime = 0;
            while (gameTime<15)
            {
                for (int i=0; i<3; i++)
                {
                    redAlliance[i].runAuto(incr);
                    blueAlliance[i].runAuto(incr);
                }
                gameTime += incr;
            }
            //accumulate points gained in auto
            for (int i = 0; i < 3; i++)
            {
                if (redAlliance[i].location.current == fieldLocation.places.blue_outerworks) autoScore += 2;
                if (blueAlliance[i].location.current == fieldLocation.places.red_outerworks) autoScore += 2;
            }

            //tele
            gameTime = 0;
            while (gameTime<135)
            {
                for (int i = 0; i < 3; i++)
                {
                    redAlliance[i].run(incr);
                    blueAlliance[i].run(incr);
                }
                gameTime += incr;
            }
        }
    }
}
