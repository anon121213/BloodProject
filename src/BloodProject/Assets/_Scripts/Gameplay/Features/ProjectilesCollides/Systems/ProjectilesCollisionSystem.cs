using _Scripts.Common.Collisions;
using Entitas;
using Knife.RealBlood;
using UnityEngine;

namespace _Scripts.Gameplay.Features.ProjectilesCollides.Systems
{
  public class ProjectilesCollisionSystem : IExecuteSystem
  {
    private readonly ICollisionRegistry _collisionRegistry;
    private readonly Collider[] _results = new Collider[16];
    private readonly IGroup<GameEntity> _projectiles;

    public ProjectilesCollisionSystem(GameContext gameContext,
      ICollisionRegistry collisionRegistry)
    {
      _collisionRegistry = collisionRegistry;

      _projectiles = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Projectile,
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.IgnoreLayers,
          GameMatcher.Transform,
          GameMatcher.Radius,
          GameMatcher.Rigidbody,
          GameMatcher.WorldPosition,
          GameMatcher.Direction
        ));
    }

    public void Execute()
    {
      foreach (var projectile in _projectiles)
      {
        Vector3 futurePosition = projectile.WorldPosition + projectile.Rigidbody.linearVelocity * Time.fixedDeltaTime;
        CheckCollisionInPath(projectile, futurePosition);
      }
    }

    private void CheckCollisionInPath(GameEntity projectile, Vector3 endPosition)
    {
      Vector3 direction = endPosition - projectile.WorldPosition;
      float distance = direction.magnitude;

      if (distance > projectile.Radius)
      {
        var size = Physics.OverlapCapsuleNonAlloc(projectile.WorldPosition,
          endPosition, projectile.Radius, _results, ~projectile.IgnoreLayers);

        if (size > 0)
          HandleCollision(projectile, _results[0], projectile.WorldPosition);
      }
    }

    private void HandleCollision(GameEntity projectile, 
      Collider collider, Vector3 collisionPoint)
    {
      projectile.Transform.position = collisionPoint;

      GameEntity entity = _collisionRegistry.Get<GameEntity>(collider.GetInstanceID());

      if (entity != null)
        projectile.ReplaceCollideEntity(entity);

      projectile.isCollide = true;
      projectile.ReplaceCollideEntityCollider(collider);
    }
  }
}