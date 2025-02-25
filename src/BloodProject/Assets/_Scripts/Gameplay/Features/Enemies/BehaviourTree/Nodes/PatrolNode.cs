using _Scripts.Common.Physics;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.BehaviourTree.Nodes
{
  public class PatrolNode : Node
  {
    private readonly IPhysicsService _physicsService;

    public PatrolNode(IPhysicsService physicsService) => 
      _physicsService = physicsService;

    public override NodeStatus Execute(GameEntity entity)
    {
      int count = _physicsService.OverlapSphereNonAlloc(entity.WorldPosition,
        entity.CheckPlayerRadius, out GameEntity[] results, entity.TargetsLayerMask);
      
      if (count > 0)
      {
        entity.isTargetAvailable = true;
        entity.ReplaceTargetId(results[0].Id);
        return NodeStatus.Success;
      }

      Debug.Log("runing");
      return NodeStatus.Running;
    }
  }
}