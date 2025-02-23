using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Collides.Systems
{
  public class CollideCleanupSystem : IExecuteSystem
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

    public void Execute()
    {
      foreach (var entity in _entities.GetEntities(_buffer))
      {
        Debug.Log("clean");
        entity.RemoveCollideEntity();
        entity.RemoveCollideEntityCollider();
        entity.isCollide = false;
      }
    }
  }
}