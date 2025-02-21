using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.Movement.System
{
  public class UpdatePositionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;
    private readonly List<GameEntity> _buffer = new(256);

    public UpdatePositionSystem(GameContext game)
    {
      _movers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Teleport,
          GameMatcher.WorldPosition,
          GameMatcher.Transform));
    }
    
    public void Execute()
    {
      foreach (GameEntity mover in _movers.GetEntities(_buffer))
      {
        mover.Transform.position = mover.WorldPosition;
        mover.isTeleport = false;
      } 
    }
  }
}