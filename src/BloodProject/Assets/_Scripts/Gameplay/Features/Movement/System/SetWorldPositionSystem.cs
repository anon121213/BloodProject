using Entitas;
using UnityEngine;

namespace Gameplay.Features.Movement.System
{
  public class SetWorldPositionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public SetWorldPositionSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.WorldPosition,
          GameMatcher.Transform
        ));
    }

    public void Execute()
    {
      foreach (var entity in _entities) 
        entity.ReplaceWorldPosition(entity.Transform.position);
    }
  }
}