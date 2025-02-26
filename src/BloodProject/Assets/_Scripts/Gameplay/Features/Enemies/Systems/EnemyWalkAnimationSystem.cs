using _Scripts.Gameplay.Features.Enemies.Animation;
using Entitas;

namespace _Scripts.Gameplay.Features.Enemies.Systems
{
  public class EnemyWalkAnimationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;

    public EnemyWalkAnimationSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.AnimatorController
        ));
    }

    public void Execute()
    {
      foreach (var enemy in _enemies)
      {
        if (enemy.isPatrol)
          enemy.AnimatorController.SetBool(EnemyAnimatorParameters.IsRun, false);
        else if (enemy.isMoving) 
          enemy.AnimatorController.SetBool(EnemyAnimatorParameters.IsRun, true);
      }
    }
  }
}