using _Scripts.Gameplay.Features.Movement.System;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Movement
{
  public class PhysicsMovementFeature : Feature
  {
    public PhysicsMovementFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<DiscretMoveRbByDirectionSystem>());
      Add(systemFactory.Create<VelocityChangeMoveRbByDirectionSystem>());
    }
  }
}