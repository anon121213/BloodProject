using _Scripts.Common.Time;
using Entitas;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
  public class AttackDelaySystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _shooters;

    public AttackDelaySystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _shooters = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Attacker,
          GameMatcher.CurrentAttackDelay,
          GameMatcher.AttackDelay
        ));
    }

    public void Execute()
    {
      foreach (var shooter in _shooters)
      {
        if (shooter.isAttack || shooter.isOnAttackDelay)
        {
          shooter.ReplaceCurrentAttackDelay(shooter.CurrentAttackDelay - _timeService.DeltaTime);

          shooter.isAttackAvailable = false;
          shooter.isAttack = false;
          shooter.isOnAttackDelay = true;
          
          if (shooter.CurrentAttackDelay <= 0)
          {
            shooter.ReplaceCurrentAttackDelay(shooter.AttackDelay);
            shooter.isAttackAvailable = true;
            shooter.isOnAttackDelay = false;
          }
        }   
      }
    }
  }
}