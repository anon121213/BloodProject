using _Scripts.Gameplay.Features.Movement.System;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Movement.System;

namespace Gameplay.Features.Movement
{
  public class PhysicsMovementFeature : Feature
  {
    public PhysicsMovementFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<MoveRbByDirectionSystem>());
    }
  }
}