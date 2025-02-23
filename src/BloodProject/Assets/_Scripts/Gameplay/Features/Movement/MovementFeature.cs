using _Scripts.Gameplay.Features.Movement.System;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Movement.System;

namespace _Scripts.Gameplay.Features.Movement
{
  public sealed class MovementFeature : Feature
  {
    public MovementFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<UpdatePositionSystem>());
      Add(systemFactory.Create<SetWorldPositionSystem>());
      Add(systemFactory.Create<SetRotationSystem>());
      Add(systemFactory.Create<MovePositionByDirectionSystem>());
      Add(systemFactory.Create<MoveCharacterControllerByDirectionSystem>());
    }
  }
}