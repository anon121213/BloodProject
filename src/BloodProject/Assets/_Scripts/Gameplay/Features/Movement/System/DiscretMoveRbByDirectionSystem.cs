using _Scripts.Common.Time;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Movement.System
{
  public class DiscretMoveRbByDirectionSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _movers;

    private Vector3 _defaultMoveVector;

    public DiscretMoveRbByDirectionSystem(GameContext gameContext, ITimeService timeService)
    {
      _time = timeService;
      _movers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Direction,
          GameMatcher.Speed,
          GameMatcher.MovementAvailable,
          GameMatcher.Rigidbody,
          GameMatcher.MoveByPhysic,
          GameMatcher.DiscreteRbMovement
        ));
    }

    public void Execute()
    {
      foreach (var mover in _movers)
      {
        if (mover.isMoving)
          mover.Rigidbody.linearVelocity = mover.Direction * mover.Speed * _time.FixedDeltaTime;
        else
        {
          _defaultMoveVector.y = mover.Rigidbody.linearVelocity.y;
          mover.Rigidbody.linearVelocity = _defaultMoveVector;
        }
      }
    }
  }
}