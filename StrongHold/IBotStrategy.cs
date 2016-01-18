using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHold
{
    interface IBotStrategy
    {
        fieldLocation.places NextLocation(fieldLocation.places current);
    }
}
