using _Scripts.Gameplay.Features.SimpleShootSystem.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.SimpleShootSystem
{
  public class ShootFeature : Feature
  {
    public ShootFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<ShootSystem>());
      Add(systemFactory.Create<Systems.SimpleShootSystem>());
    }
  }
}