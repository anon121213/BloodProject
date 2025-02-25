using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using Gameplay.Features.Effects;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.BehaviourTree.Nodes
{
  public class MoveToPlayerNode : Node
  {
    private Vector3 _lookVector;

    public override NodeStatus Execute(GameEntity entity)
    {
      if (!entity.isTargetAvailable)
        return NodeStatus.Failure;

      GameEntity target = entity.Target();
      float distance = Vector3.Distance(entity.WorldPosition, target.WorldPosition);

      if (distance > entity.DistanceToAttackPlayer && distance < entity.DistanceToPatrol)
      {
        _lookVector = (target.WorldPosition - entity.WorldPosition).normalized;

        /*Quaternion targetRotation = Quaternion.LookRotation(_lookVector);
        entity.Transform.rotation = Quaternion.Slerp(entity.Transform.rotation, 
          targetRotation, entity.RotateToPlayerSpeed * Time.deltaTime);*/

        Debug.Log("run");
        entity.ReplaceNavMashTargetPosition(target.WorldPosition);
        entity.isMoving = true;
        return NodeStatus.Running;
      }

      entity.isMoving = false;
      return distance > entity.DistanceToPatrol ? NodeStatus.Failure : NodeStatus.Success;
    }
  }
}