using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public static class StaticRoutines
    {

        public static Vector GetAngleVector(double angle)
        {
            Vector direction;

            if (angle >= Math.PI * (15d / 8d) || angle <= Math.PI * (1d / 8d)) // north
                direction = new Vector(0, 1);
            else if (angle >= Math.PI * (1d / 8d) && angle <= Math.PI * (3d / 8d)) // north east
                direction = new Vector(1, 1);
            else if (angle >= Math.PI * (3d / 8d) && angle <= Math.PI * (5d / 8d)) // east
                direction = new Vector(1, 0);
            else if (angle >= Math.PI * (5d / 8d) && angle <= Math.PI * (7d / 8d)) // south east
                direction = new Vector(1, -1);
            else if (angle >= Math.PI * (7d / 8d) && angle <= Math.PI * (9d / 8d)) // south
                direction = new Vector(0, -1);
            else if (angle >= Math.PI * (9d / 8d) && angle <= Math.PI * (11d / 8d)) // south west
                direction = new Vector(-1, -1);
            else if (angle >= Math.PI * (11d / 8d) && angle <= Math.PI * (13d / 8d)) // west
                direction = new Vector(-1, 0);
            else if (angle >= Math.PI * (13d / 8d) && angle <= Math.PI * (15d / 8d)) // north west
                direction = new Vector(-1, 1);
            else
                throw new Exception($"Unexpected angle [{angle}] generated from _r.NextDouble() * (2 * Math.PI)");

            return direction;
        }

    }
}
