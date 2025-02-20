using _Scripts.Common.Time;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Movement.System
{
  public class MoveRbByDirectionSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _movers;

    public MoveRbByDirectionSystem(GameContext gameContext, ITimeService timeService)
    {
      _time = timeService;
      _movers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Direction,
          GameMatcher.Speed,
          GameMatcher.MovementAvailable,
          GameMatcher.Rigidbody,
          GameMatcher.MoveByPhysic
        ));
    }

    public void Execute()
    {
      foreach (var mover in _movers)
      {
        if (mover.isMoving)
          mover.Rigidbody.linearVelocity = mover.Direction * mover.Speed * _time.FixedDeltaTime;
        else
          mover.Rigidbody.linearVelocity = Vector3.zero;
      }
    }
  }
}