﻿namespace Evader.EvadableAbilities.Heroes.Lich
{
    using System.Linq;

    using Common;

    using Ensage;
    using Ensage.Common.Extensions;
    using Ensage.Common.Extensions.SharpDX;

    using SharpDX;

    using static Data.AbilityNames;

    using Projectile = Base.Projectile;

    internal class ChainFrost : Projectile
    {
        #region Fields

        private readonly float jumpRadius;

        private Vector3 lastProjectilePosition;

        private bool obstacleToAOE;

        #endregion

        #region Constructors and Destructors

        public ChainFrost(Ability ability)
            : base(ability)
        {
            IsDisjointable = false;

            CounterAbilities.Add(PhaseShift);
            CounterAbilities.Add(Eul);
            CounterAbilities.Add(SleightOfFist);
            CounterAbilities.AddRange(VsDamage);
            CounterAbilities.AddRange(VsMagic);
            CounterAbilities.Add(SnowBall);
            CounterAbilities.Add(Bloodstone);
            CounterAbilities.AddRange(Invis);

            jumpRadius = Ability.AbilitySpecialData.First(x => x.Name == "jump_range").Value;
        }

        #endregion

        #region Public Methods and Operators

        public override void Check()
        {
            if (StartCast <= 0 && IsInPhase && AbilityOwner.IsVisible)
            {
                StartCast = Game.RawGameTime;
                EndCast = StartCast + CastPoint + GetCastRange() / GetProjectileSpeed();
                StartPosition = AbilityOwner.NetworkPosition;
                EndPosition = AbilityOwner.InFront(GetCastRange());
                Obstacle = Pathfinder.AddObstacle(StartPosition, EndPosition, GetRadius(), Obstacle);
            }
            else if (ProjectileTarget != null && Obstacle == null && !FowCast)
            {
                FowCast = true;
                StartCast = Game.RawGameTime;
                EndCast = StartCast + GetCastRange() / GetProjectileSpeed();
                StartPosition = AbilityOwner.NetworkPosition;
                EndPosition = StartPosition.Extend(ProjectileTarget.Position, GetCastRange());
                Obstacle = Pathfinder.AddObstacle(StartPosition, EndPosition, GetRadius(), Obstacle);
            }
            else if (StartCast > 0 && Game.RawGameTime > EndCast)
            {
                End();
            }
            else if (Obstacle != null)
            {
                if (!ProjectileLaunched())
                {
                    EndPosition = AbilityOwner.InFront(GetCastRange());
                    Pathfinder.UpdateObstacle(Obstacle.Value, StartPosition, EndPosition);
                    AbilityDrawer.UpdateRectaglePosition(StartPosition, EndPosition, GetRadius());
                }
                else if (ProjectileTarget != null)
                {
                    var projectilePosition = GetProjectilePosition(FowCast);
                    if (projectilePosition == lastProjectilePosition)
                    {
                        End();
                        return;
                    }

                    lastProjectilePosition = projectilePosition;

                    AbilityDrawer.Dispose(AbilityDrawer.Type.Rectangle);
                    EndCast = Game.RawGameTime
                              + (ProjectileTarget.Distance2D(projectilePosition) - 20) / GetProjectileSpeed();

                    if (!obstacleToAOE)
                    {
                        Obstacle = Pathfinder.AddObstacle(ProjectileTarget.Position, jumpRadius, Obstacle);
                        obstacleToAOE = true;
                    }
                    else
                    {
                        Pathfinder.UpdateObstacle(Obstacle.Value, ProjectileTarget.Position, jumpRadius);
                    }
                }
            }
        }

        public override void End()
        {
            if (Obstacle == null)
            {
                return;
            }

            base.End();

            obstacleToAOE = false;
        }

        #endregion
    }
}