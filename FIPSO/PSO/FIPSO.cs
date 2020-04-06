using FIPSO.AlgorithmParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace FIPSO.PSO
{
    class FIPSO
    {
        public FipsoParameters FipsoParameters { get; set; }
        public FipsoState FipsoState { get; set; }
        public Func<double, double, double> ApproxFunction { get; set; }
        Random Random { get; set; }

        public void Compute()
        {
            Random = new Random(FipsoParameters.Seed);
            InitiateParticles();
            InitiateVelocities();
            for(int i = 0; i < FipsoParameters.Iterations; i++)
            {
                CalculateMovements();
                MoveParticles();
                UpdateState();
            }
        }

        public void InitiateVelocities()
        {
            for (int p = 0; p < FipsoState.Particles.Count; p++)
            {
                Particle particle = FipsoState.Particles[p];
                particle.Velocity = new Vector2d(Random.NextDouble(), Random.NextDouble());
                particle.Velocity.Scale(FipsoParameters.InitialMaxSpeed);
            }
        }

        public void CalculateMovements()
        {
            List<Vector2d> forces = new List<Vector2d>();
            for (int p = 0; p < FipsoState.Particles.Count; p++)
            {
                forces.Add(new Vector2d(0, 0));
            }
            for(int p = 0; p < FipsoState.Particles.Count; p++)
            {
                for (int p2 = 0; p2 < FipsoState.Particles.Count; p2++)
                {

                }
            }
            throw new NotImplementedException();
        }

        public void MoveParticles()
        {
            throw new NotImplementedException();
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }
        public void InitiateParticles()
        {
            throw new NotImplementedException();
        }

        Vector2d GetGravityForce(int p1, int p2)
        {
            throw new NotImplementedException();
        }

        Vector2d GetElectromagneticForce(int p1, int p2)
        {
            throw new NotImplementedException();
        }

        Vector2d GetForce(Vector2d a, Vector2d b, double chargea, double chargeb, double fade)
        {
            double distance = (b - a).Lenght;
            double magnitude = chargea * chargea / Pow(distance, fade);
            Vector2d direction = (b - a).Normalize();
            return magnitude * direction;
        }

        double GetMass(double score)
        {
            throw new NotImplementedException();
        }
    }
}
