using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHold
{
    static class WorldFacts
    {
        //distance notes
        static public double neutralToOuter = 5.0;
        static public double accrossOuter = 10.0;
        static public double courtToOuter = 5.0;
        static public double courtToPosition = 5.0;
        static public double courtToBatter = 10.0;
        static public double neutralToPassage = 20.0;


        //timing notes
        static public double breachLowBar = 4.0;
        static public double probLowBar = 0.95;

        static public double breachGate = 15.0;
        static public double probGate = .75;

        static public double breachLiftGate = 15.0;
        static public double probLiftGate = .5;

        static public double breachTiltyBridge = 15.0;
        static public double probTiltyBridge = .5;

        static public double breachRoughTerrain = 7.5;
        static public double probRoughTerrain = .5;

        static public double breachMoat = 7.5;
        static public double probMoat = .5;

        static public double breachRockWall = 7.5;
        static public double probRockWall = .5;

        static public double breachRampart = 7.5;
        static public double probRampart = .5;

        static public double breachDrawBridge = 12;
        static public double probDrawBridge = .6;

       

    }
}
