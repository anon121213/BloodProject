using Entitas;

namespace _Scripts.Gameplay.Features.Projectiles.Systems
{
  public class TeleportProjectileSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _projectiles;

    public TeleportProjectileSystem(GameContext gameContext)
    {
      _projectiles =
        gameContext.GetGroup(GameMatcher
          .AllOf(
            GameMatcher.TeleportProjectile,
            GameMatcher.TeleportProjectileEndPoint,
            GameMatcher.Spawned
          ));
    }

    public void Execute()
    {
      foreach (var projectile in _projectiles)
      {
        projectile.ReplaceWorldPosition(projectile.TeleportProjectileEndPoint);
        projectile.isTeleport = true;
      }
    }
  }
}