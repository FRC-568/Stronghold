using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHold
{
    class Defense
    {
        public double friction { get; set; } //delay factor of robot getting thru, in seconds
        public double successProbability { get; set; } //how often will make it thru on first try
        public int damage { get; set; } //0=none, 1=weakened, 2=damaged
        Random r = new Random();

        public Boolean attempt()
        {
            Boolean results = false; //start with assumption we fail

            //make attempt to pass thru
            if (r.Next() < successProbability) results = true;

            //if they are going to succeed get some damage
            damage++;
            if (damage > 2) damage = 2; //max damage

            return results;
        }
    }
}
