using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHold
{
    class fieldLocation
    {

        double x;
        double y;
        double width;
        double length;
        //could use discrete field locations:
        // batter, courtyard, passage, outerworks, neutral zone
        // and then have timings getting from one location to another
        public enum places {  red_batter, red_courtyard, red_passage, red_outerworks,red_outworks_breached,
            neutral, not_set,
            blue_batter, blue_courtyard, blue_passage, blue_outerworks,blue_outerworks_breached }
        public places current;
    }
}
