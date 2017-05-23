using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.AI;
using Model.Forces;
using Mathematics;
using Bindings;

namespace Model.Species
{
    public class LeechSpecies : BoidSpecies
    {
        public static RangedDoubleParameter HunterAttractionConstant = new RangedDoubleParameter("Hunter Attraction Constant", defaultValue: 50000, minimum: 0, maximum: 100000);

        public static RangedDoubleParameter HunterAttractionExponent = new RangedDoubleParameter("Hunter Attraction Exponent", defaultValue: 0.5, minimum: 1, maximum: 10);

        public static RangedDoubleParameter PreyAttractionConstant = new RangedDoubleParameter("Prey Attraction Constant", defaultValue: 50000, minimum: 0, maximum: 100000);

        public static RangedDoubleParameter PreyAttractionExponent = new RangedDoubleParameter("Prey Attraction Exponent", defaultValue: 0.5, minimum: 1, maximum: 10);

        public static Parameter<string> FriendSpecies = new Parameter<string>("Attractive Species", "prey");

        public static Parameter<string> SecondFriendSpecies = new Parameter<string>("Attractive Species", "hunter");


        public LeechSpecies(World world) : base(world, "leech")
        {
            Bindings
                .Initialize(HunterAttractionConstant)
                .Initialize(HunterAttractionExponent)
                .Initialize(PreyAttractionConstant)
                .Initialize(PreyAttractionExponent)
                .Initialize(FriendSpecies)
                .Initialize(SecondFriendSpecies);
        }

        internal override IArtificialIntelligence CreateAI(Boid boid)
        {
            return new ArtificialIntelligence(World, boid);
        }

        private class ArtificialIntelligence : Model.AI.ArtificialIntelligence
        {
            private readonly IForce enemyForce;

            private readonly IForce friendForce;

            public ArtificialIntelligence(World world, Boid self)
                : base(world, self)
            {
                enemyForce = new BoidAttractionForce(HunterAttractionConstant, HunterAttractionExponent, SecondFriendSpecies);
                friendForce = new BoidAttractionForce(PreyAttractionConstant, PreyAttractionExponent, FriendSpecies);
            }

            public override Vector2D ComputeAcceleration()
            {
                var total = new Vector2D(0, 0);

                total += enemyForce.Compute(this.self.Bindings, this.world, this.self);
                total += friendForce.Compute(this.self.Bindings, this.world, this.self);

                return total;
            }
        }
    }
}
