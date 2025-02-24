using System.Collections.Generic;
using _Scripts.Common.Time;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Dash.Systems
{
  public class DashDelaySystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(16);

    public DashDelaySystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.DashCooldown,
          GameMatcher.CurrentDashCooldown,
          GameMatcher.OnDashCooldown
        ));
    }

    public void Execute()
    {
      foreach (var entity in _entities.GetEntities(_buffer))
      {
        if (entity.isOnEndDash)
        {
          entity.isOnEndDash = false;
          entity.ReplaceCurrentDashCooldown(entity.DashCooldown);
        }
        
        entity.ReplaceCurrentDashCooldown(entity.CurrentDashCooldown - _timeService.DeltaTime);

        if (entity.CurrentDashCooldown <= 0)
          entity.isOnDashCooldown = false;
      }
    }
  }
}