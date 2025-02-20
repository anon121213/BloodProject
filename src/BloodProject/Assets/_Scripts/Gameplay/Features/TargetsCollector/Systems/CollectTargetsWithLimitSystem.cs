using System.Collections.Generic;
using _Scripts.Common.Physics;
using Entitas;
using UnityEngine;

namespace Gameplay.Features.TargetsCollector.Systems
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
          GameMatcher.LayerMask
        ));
    }

    public void Execute()
    {
      foreach (var collector in _collectors.GetEntities(_buffer))
      {
        for (int i = 0; i < Mathf.Min(GetTargetsInRadius(collector), collector.TargetsLimit); i++)
        {
          int targetId = _targetCastBuffer[i].Id;

          if (!AlreadyProcessed(collector, targetId))
          {
            collector.TargetsBuffer.Add(targetId);
            collector.ProcessedTargets.Add(targetId);
          }
        }

        if (!collector.isCollectTargetsContinuously) 
          collector.isReadyToCollectTargets = false;
      }
    }
    
    private bool AlreadyProcessed(GameEntity entity, int targetId) => 
      entity.ProcessedTargets.Contains(targetId);

    private int GetTargetsInRadius(GameEntity entity) =>
      _physicsService.CircleCastNonAlloc(entity.WorldPosition, entity.Radius, entity.LayerMask,
        _targetCastBuffer);
  }
}