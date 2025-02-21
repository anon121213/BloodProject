using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Common.Physics;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.TargetsCollector.Systems
{
  public class CollectTargetsWithLimitSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _collectors;
    private readonly GameEntity[] _targetCastBuffer = new GameEntity[128];
    private readonly List<GameEntity> _buffer = new(16);

    public CollectTargetsWithLimitSystem(GameContext gameContext, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _collectors = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.Radius,
          GameMatcher.TargetsBuffer,
          GameMatcher.ProcessedTargets,
          GameMatcher.TargetsLimit,
          GameMatcher.WorldPosition,
          GameMatcher.LastWorldPosition,
          GameMatcher.LayerMask
        ));
    }

    public void Execute()
    {
      foreach (var collector in _collectors.GetEntities(_buffer))
      {
        GameEntity entity = GetTargetsInRadius(collector, out Collider hitCollider);
        collector.ReplaceLastWorldPosition(collector.WorldPosition);

        if (hitCollider != null)
        {
          collector.isCollide = true;
          Debug.Log("collide");
        }
        
        /*for (int i = 0; i < Mathf.Min(targetsCount.Count(), collector.TargetsLimit); i++)
        {
          collector.isCollide = true;
          Debug.Log("collide");
          
          if (_targetCastBuffer[i] == null || !_targetCastBuffer[i].hasId)
            continue;
          
          int targetId = _targetCastBuffer[i].Id;

          if (!AlreadyProcessed(collector, targetId))
          {
            collector.TargetsBuffer.Add(targetId);
            collector.ProcessedTargets.Add(targetId);
          }
        }*/

        if (!collector.isCollectTargetsContinuously) 
          collector.isReadyToCollectTargets = false;
      }
    }
    
    private bool AlreadyProcessed(GameEntity entity, int targetId) => 
      entity.ProcessedTargets.Contains(targetId);

    private GameEntity GetTargetsInRadius(GameEntity entity, out Collider hitCollider)
    {
      return _physicsService.LineCast(entity.LastWorldPosition, entity.WorldPosition, entity.LayerMask, out hitCollider);
      
    }
  }
}