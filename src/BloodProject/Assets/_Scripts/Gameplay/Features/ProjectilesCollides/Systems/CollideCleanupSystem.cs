using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.ProjectilesCollides.Systems
{
  public class CollideCleanupSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public CollideCleanupSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collide,
          GameMatcher.CollideEntity,
          GameMatcher.CollideEntityCollider
        ));
    }

    public void Cleanup()
    {
      foreach (var entity in _entities.GetEntities(_buffer))
      {
        entity.RemoveCollideEntity();
        entity.RemoveCollideEntityCollider();
        entity.isCollide = false;
      }
    }
  }
}