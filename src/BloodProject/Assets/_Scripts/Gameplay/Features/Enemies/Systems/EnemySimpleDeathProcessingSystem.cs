using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.Enemies.Systems
{
  public class EnemySimpleDeathProcessingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;
    private readonly List<GameEntity> _buffer = new (32);

    public EnemySimpleDeathProcessingSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.DestructDelay,
          GameMatcher.Dead
        ).NoneOf(GameMatcher.DeathProcessing));
    }

    public void Execute()
    {
      foreach (var enemy in _enemies.GetEntities(_buffer))
      {
        enemy.AddSelfDestructTimer(enemy.DestructDelay);
        enemy.isDeathProcessing = true;
      }
    }
  }
}