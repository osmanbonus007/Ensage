﻿namespace Evader.UsableAbilities.Items
{
    using Base;

    using Core;

    using Data;

    using Ensage;

    using EvadableAbilities.Base;

    using AbilityType = Data.AbilityType;

    internal class LinkensSphere : Targetable
    {
        #region Constructors and Destructors

        public LinkensSphere(Ability ability, AbilityType type, AbilityCastTarget target = AbilityCastTarget.Self)
            : base(ability, type, target)
        {
        }

        #endregion

        #region Public Methods and Operators

        public override bool CanBeCasted(EvadableAbility ability, Unit unit)
        {
            if (Variables.Hero.Equals(unit))
            {
                return false;
            }

            return base.CanBeCasted(ability, unit);
        }

        #endregion
    }
}