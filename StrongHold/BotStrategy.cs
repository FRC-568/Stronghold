using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//used to find next actions for a bot, example strategies are 'shooter' and 'breacher'
namespace StrongHold
{
    class BotStrategy : IBotStrategy
    {
        Bot bot;

        public BotStrategy(Bot owner)
        {
            bot = owner;
        }
        public fieldLocation.places NextLocation(fieldLocation.places current)
        {
            //given a location, where to go next?
            fieldLocation.places results = fieldLocation.places.not_set;
            switch (current)
            {
                case fieldLocation.places.not_set:
                    if (bot.team == Bot.Alliance.blue)
                        results = fieldLocation.places.red_outerworks;
                    else
                        results = fieldLocation.places.blue_outerworks;
                    bot.distancetogo = WorldFacts.neutralToOuter;
                    break;
                case fieldLocation.places.blue_outerworks:
                    bot.def = pickDefense(current);
                    if (bot.def != null)
                    {
                        bot.defenseTimetogo = bot.def.friction;
                        results = fieldLocation.places.blue_outerworks_breached;
                    }
                    break;
                case fieldLocation.places.red_outerworks:
                    bot.def = pickDefense(current);
                    if (bot.def != null)
                    {
                        bot.defenseTimetogo = bot.def.friction;
                        results = fieldLocation.places.red_outworks_breached;
                    }
                    break;
                case fieldLocation.places.red_outworks_breached:
                    if (bot.canShoot || bot.canAuto.HasFlag(Bot.autoAbility.shoot) ||bot.hasBall)
                    {
                        results = fieldLocation.places.red_courtyard;
                        bot.distancetogo = WorldFacts.courtToOuter;
                    } //otherwise, head back?
                    else
                    {
                        bot.def = pickDefense(current);
                        if (bot.def != null)
                        {
                            bot.defenseTimetogo = bot.def.friction;
                            results = fieldLocation.places.red_outerworks;
                        } //note in auto we would just sit there
                    }
                    break;

            }
            return results;
        }

        public Defense pickDefense(fieldLocation.places current)
        {
            Defense results=null;
            Defense[] options;

            if (current == fieldLocation.places.blue_outerworks)
                options = bot.field.blueOuterworks;
            else
                options = bot.field.redOuterworks;
            switch (bot.mode)
            {
                case Bot.botMode.auto:
                    switch (current)
                    {
                        case fieldLocation.places.red_outerworks:
                        case fieldLocation.places.blue_outerworks:
                            if (!bot.canAuto.HasFlag(Bot.autoAbility.breach)) return results; //bot cant breach in auto
                            results = options[3];
                            break;
                        case fieldLocation.places.red_outworks_breached:
                        case fieldLocation.places.blue_outerworks_breached:
                            results = null; //in auto you dont go back
                            break;
                    }
                    break;
                case Bot.botMode.tele:
                    results = options[3];
                    break;
            }
            return results;
        }
    }
}
