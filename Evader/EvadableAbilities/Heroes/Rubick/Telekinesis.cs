﻿namespace Evader.EvadableAbilities.Heroes.Rubick
{
    using System.Linq;

    using Base;
    using Base.Interfaces;

    using Ensage;

    using Modifiers;

    using static Data.AbilityNames;

    internal class Telekinesis : EvadableAbility, IModifier
    {
        #region Constructors and Destructors

        public Telekinesis(Ability ability)
            : base(ability)
        {
            Modifier = new EvadableModifier(HeroTeam, EvadableModifier.GetHeroType.LowestHealth);

            Modifier.AllyCounterAbilities.Add(Enrage);
            Modifier.AllyCounterAbilities.AddRange(AllyShields);
            Modifier.AllyCounterAbilities.AddRange(Invul);

            AdditionalDelay = Ability.AbilitySpecialData.First(x => x.Name == "lift_duration").GetValue(3);
        }

        #endregion

        #region Public Properties

        public EvadableModifier Modifier { get; }

        #endregion

        #region Public Methods and Operators

        public override void Check()
        {
        }

        public override void Draw()
        {
        }

        public override float GetRemainingTime(Hero hero = null)
        {
            return 0;
        }

        #endregion
    }
}