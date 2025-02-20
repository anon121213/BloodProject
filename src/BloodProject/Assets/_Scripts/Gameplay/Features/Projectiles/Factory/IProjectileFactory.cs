using Gameplay.Features.Projectiles.Data;
using UnityEngine;

namespace Gameplay.Features.Projectiles.Factory
{
  public interface IProjectileFactory
  {
    GameEntity CreateSimpleBulletProjectile(ProjectileData projectileData, int producerID, Vector2 at, Quaternion rotation);
  }
}