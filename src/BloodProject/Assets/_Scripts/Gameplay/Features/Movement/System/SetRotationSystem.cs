using Entitas;

namespace Gameplay.Features.Movement.System
{
  public class SetRotationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public SetRotationSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Transform,
          GameMatcher.WorldRotation
        ));
    }

    public void Execute()
    {
      foreach (var entity in _entities)
      {
        if (entity.Transform.rotation != entity.WorldRotation)
          entity.Transform.rotation = entity.WorldRotation;
      }
    }
  }
}