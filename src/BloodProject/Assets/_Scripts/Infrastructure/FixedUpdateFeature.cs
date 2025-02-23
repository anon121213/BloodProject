using _Scripts.Gameplay.Features.Collides;
using _Scripts.Gameplay.Features.Movement;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Infrastructure
{
  public sealed class FixedUpdateFeature : Feature
  {
    public FixedUpdateFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<PhysicsMovementFeature>());
      Add(systemFactory.Create<CollideFeature>());
    }
  }
}