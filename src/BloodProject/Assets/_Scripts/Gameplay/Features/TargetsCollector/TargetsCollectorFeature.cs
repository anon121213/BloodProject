using _Scripts.Gameplay.Features.TargetsCollector.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.TargetsCollector.Systems;

namespace Gameplay.Features.TargetsCollector
{
  public class TargetsCollectorFeature : Feature
  {
    public TargetsCollectorFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CollectTargetsIntervalSystem>());
      Add(systemFactory.Create<CollectTargetsWithLimitSystem>());
      Add(systemFactory.Create<TargetsCleanupSystem>());
    }
  }
}