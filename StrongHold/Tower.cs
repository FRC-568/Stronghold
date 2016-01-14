using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHold
{
    class Tower
    {
        public int strength { get; set; } //0=assualt ready, 8=normal max

        public Tower()
        {
            strength = 8;
        }

        public void hit()
        {
            strength--;
            if (strength < 0) strength = 0;
        }
    }
}
