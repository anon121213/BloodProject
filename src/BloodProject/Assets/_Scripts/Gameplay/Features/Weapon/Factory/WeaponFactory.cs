using System;
using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using _Scripts.Gameplay.Features.Weapon.Data;
using _Scripts.Gameplay.Features.Weapon.Data.Base;
using _Scripts.Gameplay.Features.Weapon.Data.Gauss;
using _Scripts.Gameplay.Features.Weapon.Data.Shotgun;
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

    public GameEntity CreateWeapon(WeaponTypes type, Transform holder, int OwnerId)
    {
      WeaponConfig config = _staticDataProvider.WeaponConfigs.GetWeaponConfig(type);

      switch (type)
      {
        case WeaponTypes.Rifle:
          return CreateRifle(config, holder).AddOwnerID(OwnerId);
        
        case WeaponTypes.Shotgun:
          return CreateShotgun(config, holder).AddOwnerID(OwnerId);
        
        case WeaponTypes.Gauss:
          return CreateGauss(config, holder).AddOwnerID(OwnerId);
        
        case WeaponTypes.Unknown:
          throw new Exception($"Weapon type is Unknown");
      }

      return null;
    }

    private GameEntity CreateShotgun(WeaponConfig config, Transform holder)
    {
      ShotgunConfig shotgunConfig = (ShotgunConfig)config;
      
      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddWorldPosition(Vector3.zero)
        .AddWorldRotation(Quaternion.Euler(Vector3.zero))
        .AddAttackDelay(config.WeaponSettings.ShootDelay)
        .AddCurrentAttackDelay(config.WeaponSettings.ShootDelay)
        .AddViewReference(config.Prefab)
        .AddViewRoot(holder)
        .AddPelletCount(shotgunConfig.PelletCount)
        .AddSpredAngleX(shotgunConfig.SpredAngleX)
        .AddSpredAngleY(shotgunConfig.SpredAngleY)
        .AddRayDistance(shotgunConfig.RayDistance)
        .AddIgnoreLayers(shotgunConfig.IgnoreLayers)
        .AddEffectSetups(shotgunConfig.EffectSetups)
        .With(x => x.isWeapon = true)
        .With(x => x.isRaycastShooter = true)
        .With(x => x.isShotgun = true)
        .With(x => x.isAttacker = true)
        .With(x => x.isAttackAvailable = true);
    }

    private GameEntity CreateRifle(WeaponConfig config, Transform holder)
    {
      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddWorldPosition(Vector3.zero)
        .AddWorldRotation(Quaternion.Euler(Vector3.zero))
        .AddProjectileData(config.BulletConfig)
        .AddAttackDelay(config.WeaponSettings.ShootDelay)
        .AddCurrentAttackDelay(config.WeaponSettings.ShootDelay)
        .AddViewReference(config.Prefab)
        .AddViewRoot(holder)
        .With(x => x.isWeapon = true)
        .With(x => x.isAttacker = true)
        .With(x => x.isProjectileBulletShooter = true)
        .With(x => x.isAttackAvailable = true);
    }
    
    private GameEntity CreateGauss(WeaponConfig config, Transform holder)
    {
      GaussConfig gaussConfig = (GaussConfig)config;

      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddWorldPosition(Vector3.zero)
        .AddWorldRotation(Quaternion.Euler(Vector3.zero))
        .AddAttackDelay(config.WeaponSettings.ShootDelay)
        .AddCurrentAttackDelay(config.WeaponSettings.ShootDelay)
        .AddViewReference(config.Prefab)
        .AddViewRoot(holder)
        .AddIgnoreLayers(gaussConfig.IgnoreLayers)
        .AddRayDistance(gaussConfig.RayDistance)
        .AddEffectSetups(gaussConfig.EffectSetups)
        .AddPushDistance(gaussConfig.PushDistance)
        .AddPushDuration(gaussConfig.PushDuration)
        .AddProjectileData(config.BulletConfig)
        .With(x => x.isWeapon = true)
        .With(x => x.isGauss = true)
        .With(x => x.isAttacker = true)
        .With(x => x.isRaycastShooter = true)
        .With(x => x.isAttackAvailable = true);
    }
  }
}