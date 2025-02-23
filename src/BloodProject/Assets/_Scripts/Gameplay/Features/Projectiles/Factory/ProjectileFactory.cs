using System.Collections.Generic;
using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using _Scripts.Gameplay.Features.Projectiles.Data;
using _Scripts.Infrastructure.Services.Identifiers;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Projectiles.Factory
{
  public class ProjectileFactory : IProjectileFactory
  {
    private const int TargetBufferSize = 16;
    
    public GameEntity CreateSimpleBulletProjectile(ProjectileConfig projectileConfig, int producerID, Vector3 at, Quaternion rotation, Vector3 direction)
    {
      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddProducerId(producerID)
        .AddWorldPosition(at)
        .AddLastWorldPosition(at)
        .AddWorldRotation(rotation)
        .AddSpeed(projectileConfig.Speed)
        .AddDirection(direction)
        .AddEffectSetups(projectileConfig.EffectSetups)
        .AddViewReference(projectileConfig.Prefab)
        .AddSelfDestructTimer(projectileConfig.LifeTime)
        .AddLayerMask(projectileConfig.CollisionLayerMask)
        .With(x => x.isProjectile = true)
        .With(x => x.isSimpleBulletProjectile = true)
        .With(x => x.isReadyToCollectTargets = true)
        .With(x => x.isMoving = true)
        .With(x => x.isTeleport = true)
        .With(x => x.isRotate = true)
        .With(x => x.isMoveByPhysic = true)
        .With(x => x.isMovementAvailable = true);
    }
  }
}
