using _Scripts.Common.Time;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Movement.System
{
  public class VelocityChangeMoveRbByDirectionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;

    public VelocityChangeMoveRbByDirectionSystem(GameContext gameContext)
    {
      _movers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Direction,
          GameMatcher.Speed,
          GameMatcher.MovementAvailable,
          GameMatcher.Rigidbody,
          GameMatcher.MoveByPhysic
        )
        .NoneOf(GameMatcher.DiscreteRbMovement));
    }

    public void Execute()
    {
      foreach (var mover in _movers)
      {
        if (mover.isMoving)
        {
          Vector3 targetVelocity = mover.Direction * mover.Speed;
          Vector3 velocityChange = targetVelocity - mover.Rigidbody.linearVelocity;
          mover.Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
      }
    }
  }
}