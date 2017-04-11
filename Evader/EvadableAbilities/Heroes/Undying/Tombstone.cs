﻿namespace Evader.EvadableAbilities.Heroes.Undying
{
    using Base;

    using Ensage;

    using static Data.AbilityNames;

    internal class Tombstone : NoObstacleAbility
    {
        #region Constructors and Destructors

        public Tombstone(Ability ability)
            : base(ability)
        {
            DisableAbilities.AddRange(DisableAbilityNames);
        }

        #endregion
    }
}