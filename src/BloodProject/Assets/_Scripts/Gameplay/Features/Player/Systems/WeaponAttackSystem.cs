using Entitas;

namespace _Scripts.Gameplay.Features.Player.Systems
{
  public class WeaponAttackSystem : IExecuteSystem
  {
    private readonly IGroup<InputEntity> _inputs;
    private readonly IGroup<GameEntity> _player;
    private readonly GameContext _game;

    public WeaponAttackSystem(InputContext inputContext,
      GameContext gameContext)
    {
      _game = gameContext;
      _inputs = inputContext.GetGroup(InputMatcher
        .AllOf(
          InputMatcher.Input
        ));

      _player = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.CurrentWeapon
        ));
    }

    public void Execute()
    {
      foreach (var input in _inputs)
      foreach (var player in _player)
      {
        if (!input.isShooting)
          continue;

        GameEntity currentWeapon = _game.GetEntityWithId(player.CurrentWeapon);
        
        if (currentWeapon.isAttackAvailable) 
          currentWeapon.isAttack = true;
      }
    }
  }
}