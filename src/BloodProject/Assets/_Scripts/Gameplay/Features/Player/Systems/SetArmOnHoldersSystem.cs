using Entitas;

namespace _Scripts.Gameplay.Features.Player.Systems
{
  public class SetArmOnHoldersSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<GameEntity> _weapons;

    public SetArmOnHoldersSystem(GameContext gameContext)
    {
      _players = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.RightHand,
          GameMatcher.LeftHand,
          GameMatcher.CurrentWeapon,
          GameMatcher.RigBuilder
        ));

      _weapons = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Weapon,
          GameMatcher.LeftHandHolder,
          GameMatcher.RightHandHolder
        ));
    }

    public void Execute()
    {
      foreach (var player in _players)
      foreach (var weapon in _weapons)
      {
        if (weapon.Id != player.CurrentWeapon)
          continue;
        
        player.RightHand.data.target = weapon.RightHandHolder;
        player.LeftHand.data.target = weapon.LeftHandHolder;
        player.RigBuilder.enabled = true;
      }
    }
  }
}