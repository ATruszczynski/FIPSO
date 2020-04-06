﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPSO.AlgorithmParts
{
    class FipsoState
    {
        public List<Particle> Particles { get; set; }
        public Vector2d BestSol { get; set; }
    }
}
