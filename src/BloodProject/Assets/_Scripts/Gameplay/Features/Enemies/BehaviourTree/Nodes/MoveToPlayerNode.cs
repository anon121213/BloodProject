using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using Gameplay.Features.Effects;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.BehaviourTree.Nodes
{
  public class MoveToPlayerNode : Node
  {
    private Vector3 _moveVector;

    public override NodeStatus Execute(GameEntity entity)
    {
      if (!entity.isTargetAvailable)
        return NodeStatus.Failure;

      GameEntity target = entity.Target();
      float distance = Vector3.Distance(entity.WorldPosition, target.WorldPosition);

      if (distance > entity.DistanceToAttackPlayer && distance < entity.DistanceToPatrol)
      {
        _moveVector = (target.WorldPosition - entity.WorldPosition).normalized;
        _moveVector.y = entity.Rigidbody.linearVelocity.y;

        Quaternion targetRotation = Quaternion.LookRotation(_moveVector);
        entity.Transform.rotation = Quaternion.Slerp(entity.Transform.rotation, 
          targetRotation, entity.RotateToPlayerSpeed * Time.deltaTime);

        entity.ReplaceDirection(_moveVector);
        entity.isMoving = true;
        return NodeStatus.Running;
      }

      entity.isMoving = false;
      return distance > entity.DistanceToPatrol ? NodeStatus.Failure : NodeStatus.Success;
    }
  }
}