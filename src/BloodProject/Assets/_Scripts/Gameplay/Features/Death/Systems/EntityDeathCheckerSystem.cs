using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.Health.Systems
{
  public class EntityDeathCheckerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;
    private readonly List<GameEntity> _buffer = new(32);

    public EntityDeathCheckerSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(GameMatcher.CurrentHealth)
        .NoneOf(GameMatcher.Dead));
    }

    public void Execute()
    {
      foreach (var enemy in _enemies.GetEntities(_buffer))
        if (enemy.CurrentHealth <= 0) 
          enemy.isDead = true;
    }
  }
}