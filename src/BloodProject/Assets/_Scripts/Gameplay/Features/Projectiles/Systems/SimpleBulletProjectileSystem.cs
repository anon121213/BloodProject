using Entitas;

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
          GameMatcher.Direction,
          GameMatcher.Transform
        ));
    }

    public void Execute()
    {
      foreach (var projectile in _projectiles)
      {
        if (projectile.Direction != projectile.Transform.forward.normalized)
        {
          projectile.ReplaceDirection(projectile.Transform.forward.normalized);
        }
      } 
    }
  }
}