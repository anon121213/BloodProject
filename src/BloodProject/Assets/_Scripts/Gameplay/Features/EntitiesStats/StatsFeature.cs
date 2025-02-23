using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.EntitiesStats.Systems;

namespace _Scripts.Gameplay.Features.EntitiesStats
{
  public sealed class StatsFeature : Feature
  {
    public StatsFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<StatChangeSystem>());
      Add(systemFactory.Create<ApplySpeedChangeSystem>());
    }    
  }
}