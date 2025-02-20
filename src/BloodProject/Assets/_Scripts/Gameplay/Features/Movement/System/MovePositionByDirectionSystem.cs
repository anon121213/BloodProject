using _Scripts.Common.Time;
using Entitas;
using UnityEngine;

namespace Gameplay.Features.Movement.System
{
  public class MovePositionByDirectionSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _movers;

    public MovePositionByDirectionSystem(GameContext gameContext, ITimeService timeService)
    {
      _time = timeService;
      _movers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Direction,
          GameMatcher.MovementAvailable,
          GameMatcher.WorldPosition,
          GameMatcher.Speed,
          GameMatcher.Moving
        )
        .NoneOf(GameMatcher.MoveByPhysic));
    }
    
    public void Execute()
    {
      foreach (var mover in _movers)
      {
        mover.ReplaceWorldPosition(mover.WorldPosition + mover.Direction * mover.Speed * _time.DeltaTime);
        mover.isTeleport = true;
      }
    }
  }
}