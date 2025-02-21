using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Movement;
using Gameplay.Features.TargetsCollector;

namespace _Scripts.Infrastructure
{
  public class FixedUpdateFeature : Feature
  {
    public FixedUpdateFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<PhysicsMovementFeature>());
      Add(systemFactory.Create<TargetsCollectorFeature>());
    }
  }
}