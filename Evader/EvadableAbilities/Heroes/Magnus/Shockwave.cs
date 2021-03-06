﻿namespace Evader.EvadableAbilities.Heroes.Magnus
{
    using Ensage;

    using static Data.AbilityNames;

    using LinearProjectile = Base.LinearProjectile;

    internal class Shockwave : LinearProjectile
    {
        #region Constructors and Destructors

        public Shockwave(Ability ability)
            : base(ability)
        {
            CounterAbilities.Add(PhaseShift);
            CounterAbilities.Add(BallLightning);
            CounterAbilities.AddRange(VsDamage);
            CounterAbilities.AddRange(VsMagic);
            CounterAbilities.Add(Armlet);
            CounterAbilities.Add(Bloodstone);
        }

        #endregion

        #region Methods

        protected override float GetEndRadius()
        {
            return base.GetRadius() + 60;
        }

        protected override float GetRadius()
        {
            return base.GetRadius() + 60;
        }

        #endregion
    }
}