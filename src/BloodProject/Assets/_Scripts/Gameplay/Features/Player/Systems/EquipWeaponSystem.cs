using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.Player.Systems
{
  public class EquipWeaponSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly GameContext _gameContext;
    private readonly List<GameEntity> _buffer = new(10);

    public EquipWeaponSystem(GameContext gameContext)
    {
      _gameContext = gameContext;
      _players = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.WeaponHolder,
          GameMatcher.RigBuilder,
          GameMatcher.ExistingWeapons,
          GameMatcher.EquipWeapon,
          GameMatcher.CurrentWeapon,
          GameMatcher.EquipWeaponEntity
        ));
    }

    public void Execute()
    {
      foreach (var player in _players.GetEntities(_buffer))
      {
        GameEntity currentWeapon = _gameContext.GetEntityWithId(player.CurrentWeapon);
        currentWeapon?.Transform.gameObject.SetActive(false);

        player.ReplaceCurrentWeapon(player.EquipWeaponEntity);
        GameEntity newCurrentWeapon = _gameContext.GetEntityWithId(player.CurrentWeapon);
        newCurrentWeapon?.Transform.gameObject.SetActive(true);
        player.RigBuilder.enabled = false;
        player.isEquipWeapon = false;
      }
    }
  }
}