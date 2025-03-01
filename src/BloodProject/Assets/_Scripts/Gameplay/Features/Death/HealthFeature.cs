using _Scripts.Gameplay.Features.Health.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Death
{
  public sealed class HealthFeature : Feature
  {
    public HealthFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<EntityDeathCheckerSystem>());
    }
  }
}