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
            redAlliance[0] = new Bot(Bot.teleAbility.shoot|Bot.teleAbility.climb, Bot.autoAbility.none,Bot.Alliance.red);
            redAlliance[1] = new Bot(Bot.teleAbility.shoot | Bot.teleAbility.climb, Bot.autoAbility.none, Bot.Alliance.red);
            redAlliance[2] = new Bot(Bot.teleAbility.shoot | Bot.teleAbility.climb, Bot.autoAbility.none, Bot.Alliance.red);
            blueAlliance[0] = new Bot(Bot.teleAbility.breach, Bot.autoAbility.breach, Bot.Alliance.blue);
            blueAlliance[1] = new Bot(Bot.teleAbility.breach, Bot.autoAbility.breach, Bot.Alliance.blue);
            blueAlliance[2] = new Bot(Bot.teleAbility.breach, Bot.autoAbility.breach, Bot.Alliance.blue);
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
