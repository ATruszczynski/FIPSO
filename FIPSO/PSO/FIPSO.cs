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
        public Func<Vector2d, double> ApproxFunction { get; set; }
        Random Random { get; set; }

        public void Compute()
        {
            Random = new Random(FipsoParameters.Seed);
            InitiateParticles(FipsoParameters.masses, FipsoParameters.charges);
            for(int i = 0; i < FipsoParameters.Iterations; i++)
            {
                MoveParticles();
                CalculateVelocities();
            }
        }

        public void InitiateParticles(List<double> masses, List<double> charges)
        {
            for (int p = 0; p < FipsoParameters.ParticleCount; p++)
            {
                var vel = new Vector2d(Random.NextDouble(), Random.NextDouble());
                vel.Scale(FipsoParameters.InitialMaxSpeed);
                var pos = new Vector2d(Random.NextDouble(), Random.NextDouble());
                pos = FipsoParameters.ParticleSpreadRadius * pos;
                Particle particle = new Particle(vel, masses[p], charges[p]);
            }
        }

        public void CalculateVelocities()
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
                    Vector2d grav = GetGravityForce(p, p2);
                    Vector2d elec = GetElectromagneticForce(p, p2);
                    forces[p] += grav;
                    forces[p] += elec;
                    forces[p2] -= grav;
                    forces[p2] -= elec;
                }
            }
            for (int p = 0; p < FipsoState.Particles.Count; p++)
            {
                Particle par = FipsoState.Particles[p];
                par.Velocity += forces[p] / par.Mass;
            }
        }

        public void MoveParticles()
        {
            for (int p = 0; p < FipsoState.Particles.Count; p++)
            {
                Particle par = FipsoState.Particles[p];
                par.Position += par.Velocity;
                double currScore = ApproxFunction.Invoke(par.Position);
                if (currScore > ApproxFunction.Invoke(par.PersonalBest))
                    par.PersonalBest = par.Position;
                if (currScore > FipsoState.BestSolScore)
                {
                    FipsoState.BestSol = par.Position;
                    FipsoState.BestSolScore = currScore;
                }
                if (currScore < FipsoState.WorstSolScore)
                {
                    FipsoState.WorstSol = par.Position;
                    FipsoState.WorstSolScore = currScore;
                }
            }
        }

        Vector2d GetGravityForce(int p1, int p2)
        {
            Particle par1 = FipsoState.Particles[p1];
            Particle par2 = FipsoState.Particles[p2];
            return GetForce(par1.PersonalBest, par2.PersonalBest, par1.Mass, GetMass(ApproxFunction.Invoke(par2.PersonalBest)), FipsoParameters.GravityFade);
        }

        Vector2d GetElectromagneticForce(int p1, int p2)
        {
            Particle par1 = FipsoState.Particles[p1];
            Particle par2 = FipsoState.Particles[p2];
            return -GetForce(par1.Position, par2.Position, par1.Charge, par2.Charge, FipsoParameters.ElectromagnetismFade);
        }

        Vector2d GetForce(Vector2d a, Vector2d b, double chargea, double chargeb, double fade)
        {
            double distance = (b - a).Lenght;
            if (distance == 0)
                return new Vector2d(0, 0); //?
            double magnitude = chargea * chargea / Pow(distance, fade);
            Vector2d direction = (b - a).Normalize();
            return magnitude * direction;
        }

        double GetMass(double score)
        {
            double numerator = score - FipsoState.BestSolScore;
            double denominator = FipsoState.BestSolScore - FipsoState.WorstSolScore;
            double frac = 1 - Pow(numerator/ denominator,2);
            return FipsoParameters.MaxMass * frac;
        }
    }
}
