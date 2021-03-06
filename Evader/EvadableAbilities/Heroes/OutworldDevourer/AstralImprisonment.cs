﻿namespace Evader.EvadableAbilities.Heroes.OutworldDevourer
{
    using Base;

    using Ensage;

    using static Data.AbilityNames;

    internal class AstralImprisonment : LinearTarget
    {
        #region Constructors and Destructors

        public AstralImprisonment(Ability ability)
            : base(ability)
        {
            CounterAbilities.Add(PhaseShift);
            CounterAbilities.Add(BallLightning);
            CounterAbilities.Add(Manta);
            CounterAbilities.Add(Bloodstone);
            CounterAbilities.Add(Lotus);
        }

        #endregion
    }
}