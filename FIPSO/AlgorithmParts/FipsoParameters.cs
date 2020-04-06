using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIPSO.AlgorithmParts
{
    class FipsoParameters
    {
        public int Seed { get; set; }
        public int Iterations { get; set; }
        public double InitialMaxSpeed { get; set; }
        public int ParticleCount { get; set; }
        public Vector2d ParticleSpreadCenter { get; set; }
        public double ParticleSpreadRadius { get; set; }
        public double PersonalBestCoefficient { get; set; }
        public double OtherBestCoefficient { get; set; }
        public double GravityFade { get; set; }
        public double ElectromagnetismFade { get; set; }
        public List<double> masses { get; set; }
        public List<double> charges { get; set; }
        public double MaxMass { get; set; }
    }
}
