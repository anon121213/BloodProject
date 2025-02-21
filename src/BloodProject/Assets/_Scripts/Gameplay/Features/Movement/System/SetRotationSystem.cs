using System.Collections.Generic;
using Entitas;

namespace Gameplay.Features.Movement.System
{
  public class SetRotationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public SetRotationSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Transform,
          GameMatcher.WorldRotation,
          GameMatcher.Rotate
        ));
    }

    public void Execute()
    {
      foreach (var entity in _entities.GetEntities(_buffer))
      {
        if (entity.Transform.rotation != entity.WorldRotation)
        {
          entity.Transform.rotation = entity.WorldRotation;
          entity.isRotate = false;
        }
      }
    }
  }
}