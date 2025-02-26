using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.Animation
{
  public static class EnemyAnimatorParameters
  {
    public static readonly int IsRun = Animator.StringToHash("IsRun");
    public static readonly int IsWalk = Animator.StringToHash("IsWalk");
    public static readonly int IsWalkBack = Animator.StringToHash("IsWalkBack");
    public static readonly int JumpTrigger = Animator.StringToHash("JumpTrigger");
    public static readonly int DashTrigger = Animator.StringToHash("DashTrigger");
    public static readonly int HitTrigger = Animator.StringToHash("HitTrigger");
    public static readonly int AttackTrigger = Animator.StringToHash("AttackTrigger");
    public static readonly int ComboCount = Animator.StringToHash("ComboCount");
    public static readonly int DeathTrigger = Animator.StringToHash("DeathTrigger");
  }
}