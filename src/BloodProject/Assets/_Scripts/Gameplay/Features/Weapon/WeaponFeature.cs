using _Scripts.Gameplay.Features.Weapon.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Weapon
{
  public class WeaponFeature : Feature
  {
    public WeaponFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<WeaponShootSystem>());
      Add(systemFactory.Create<ShootDelaySystem>());
    }
  }
}