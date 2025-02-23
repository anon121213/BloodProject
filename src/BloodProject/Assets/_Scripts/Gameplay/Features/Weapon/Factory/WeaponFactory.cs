using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using _Scripts.Gameplay.Features.Weapon.Data;
using _Scripts.Gameplay.Features.Weapon.Data.Base;
using _Scripts.Infrastructure.Services.Identifiers;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Factory
{
  public class WeaponFactory : IWeaponFactory
  {
    private readonly IStaticDataProvider _staticDataProvider;

    public WeaponFactory(IStaticDataProvider staticDataProvider) => 
      _staticDataProvider = staticDataProvider;

    public GameEntity CreateWeapon(WeaponTypes type, Transform holder)
    {
      WeaponConfig config = _staticDataProvider.WeaponConfigs.GetWeaponConfig(type);

      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddWorldPosition(Vector3.zero)
        .AddWorldRotation(Quaternion.Euler(Vector3.zero))
        .AddProjectileData(config.BulletConfig)
        .AddShootDelay(config.WeaponSettings.ShootDelay)
        .AddCurrentShootDelay(0)
        .AddViewReference(config.Prefab)
        .AddViewRoot(holder)
        .With(x => x.isWeapon = true)
        .With(x => x.isShooter = true)
        .With(x => x.isShootAvailable = true);
    }
  }
}