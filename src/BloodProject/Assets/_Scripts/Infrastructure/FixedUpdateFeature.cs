using _Scripts.Gameplay.Features.Camera;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Movement;

namespace _Scripts.Infrastructure
{
  public class FixedUpdateFeature : Feature
  {
    public FixedUpdateFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<PhysicsMovementFeature>());
    }
  }
}