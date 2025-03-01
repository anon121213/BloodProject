using _Scripts.Gameplay.Features.Enemies.Animation;
using Entitas;

namespace _Scripts.Gameplay.Features.Enemies.Systems
{
  public class EnemyPatrolAnimationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;

    public EnemyPatrolAnimationSystem(GameContext gameContext)
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
        enemy.AnimatorController.SetBool(EnemyAnimatorParameters.IsPatrol, enemy.isPatrol);
    }
  }
}