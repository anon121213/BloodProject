using System.Collections.Generic;
using Entitas;

namespace Gameplay.Features.Projectiles.Systems
{
  public class ProjectilesDeathProcessingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _projectiles;
    private readonly List<GameEntity> _buffer = new(32);

    public ProjectilesDeathProcessingSystem(GameContext gameContext)
    {
      _projectiles = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Projectile,
          GameMatcher.TargetsLimit,
          GameMatcher.ProcessedTargets
        ));
    }

    public void Execute()
    {
      foreach (var projectile in _projectiles.GetEntities(_buffer))
      {
        if (projectile.TargetsLimit <= projectile.ProcessedTargets.Count)
        {
          projectile.isDestructed = true;
        }
      }
    }
  }
}