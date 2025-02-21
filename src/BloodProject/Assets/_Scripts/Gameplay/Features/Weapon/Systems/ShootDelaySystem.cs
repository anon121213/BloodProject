using _Scripts.Common.Time;
using Entitas;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
  public class ShootDelaySystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _shooters;

    public ShootDelaySystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _shooters = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Shooter,
          GameMatcher.CurrentShootDelay,
          GameMatcher.ShootDelay
        ));
    }

    public void Execute()
    {
      foreach (var shooter in _shooters)
      {
        if (shooter.isShoot || shooter.isOnShootDelay)
        {
          shooter.ReplaceCurrentShootDelay(shooter.CurrentShootDelay - _timeService.DeltaTime);

          shooter.isShootAvailable = false;
          shooter.isShoot = false;
          shooter.isOnShootDelay = true;
          
          if (shooter.CurrentShootDelay <= 0)
          {
            shooter.ReplaceCurrentShootDelay(shooter.ShootDelay);
            shooter.isShootAvailable = true;
            shooter.isOnShootDelay = false;
          }
        }   
      }
    }
  }
}