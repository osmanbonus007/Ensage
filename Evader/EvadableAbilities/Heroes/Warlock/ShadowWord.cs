﻿namespace Evader.EvadableAbilities.Heroes.Warlock
{
    using Base;
    using Base.Interfaces;

    using Ensage;

    using Modifiers;

    using static Data.AbilityNames;

    internal class ShadowWord : LinearTarget, IModifier
    {
        #region Constructors and Destructors

        public ShadowWord(Ability ability)
            : base(ability)
        {
            Modifier = new EvadableModifier(HeroTeam, EvadableModifier.GetHeroType.ModifierSource);

            CounterAbilities.Add(PhaseShift);

            Modifier.AllyCounterAbilities.Add(Lotus);
            Modifier.AllyCounterAbilities.AddRange(AllyShields);
            Modifier.AllyCounterAbilities.Add(Manta);
            Modifier.AllyCounterAbilities.Add(Eul);
        }

        #endregion

        #region Public Properties

        public EvadableModifier Modifier { get; }

        #endregion
    }
}