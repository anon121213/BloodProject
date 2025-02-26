using _Scripts.Gameplay.Features.Enemies.Animation;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.Systems
{
  public class EnemyAttackAnimationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;

    public EnemyAttackAnimationSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.AnimatorController,
          GameMatcher.AttackCombo,
          GameMatcher.Attack
        ));
    }

    public void Execute()
    {
      foreach (var enemy in _enemies)
      {
        enemy.AnimatorController.SetInteger(EnemyAnimatorParameters.ComboCount, enemy.AttackCombo);
        enemy.AnimatorController.SetTrigger(EnemyAnimatorParameters.AttackTrigger);
      }
    }

    private int GetAttackParameter(int num) => 
      Animator.StringToHash($"Attack{num}Speed");
  }
}