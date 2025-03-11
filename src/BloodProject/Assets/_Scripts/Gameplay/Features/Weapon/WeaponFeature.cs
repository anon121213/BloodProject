using _Scripts.Gameplay.Features.Weapon.Systems;
using _Scripts.Gameplay.Features.Weapon.Systems.Delay;
using _Scripts.Gameplay.Features.Weapon.Systems.HittablesEntities;
using _Scripts.Gameplay.Features.Weapon.Systems.RayCast;
using _Scripts.Gameplay.Features.Weapon.Systems.ShootTypes;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Weapon
{
  public sealed class WeaponFeature : Feature
  {
    public WeaponFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<ProjectileShootSystem>());
      Add(systemFactory.Create<ShotgunRayCastWeaponSystem>());
      Add(systemFactory.Create<GaussRayCastSystem>());
      Add(systemFactory.Create<MultipleShootRayCastSystem>());
      Add(systemFactory.Create<RayCastDamageSystem>());
      Add(systemFactory.Create<RayCastBloodHandler>());
      Add(systemFactory.Create<AttackDelaySystem>());
      Add(systemFactory.Create<HittableEntitiesCleanupSystem>());
      Add(systemFactory.Create<RayCastBloodCleanupSystem>());
      Add(systemFactory.Create<ShootRayCastCleanupSystem>());
    }
  }
}