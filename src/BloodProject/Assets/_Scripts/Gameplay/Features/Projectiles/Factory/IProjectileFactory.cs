using _Scripts.Gameplay.Features.Projectiles.Data;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Projectiles.Factory
{
  public interface IProjectileFactory
  {
    GameEntity CreateSimpleBulletProjectile(ProjectileData projectileData, int producerID, Vector3 at, Quaternion rotation);
  }
}