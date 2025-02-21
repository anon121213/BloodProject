using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Projectiles.Systems
{
  public class SimpleBulletProjectileSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _projectiles;

    public SimpleBulletProjectileSystem(GameContext gameContext)
    {
      _projectiles = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.SimpleBulletProjectile,
          GameMatcher.Collide
        ));
    }

    public void Execute()
    {
      foreach (var projectile in _projectiles)
      {
        Debug.Log("destroy");
        projectile.isDestructed = true;
      } 
    }
  }
}