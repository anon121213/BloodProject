using _Scripts.Gameplay.Features.Dash.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Dash
{
  public sealed class DashFeature : Feature
  {
    public DashFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CharacterControllerDashSystem>());
      Add(systemFactory.Create<DashDelaySystem>());
      Add(systemFactory.Create<DashDurationSystem>());
    }
  }
}