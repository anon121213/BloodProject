using System.Collections.Generic;
using _Scripts.Gameplay.Features.Weapon.Data;
using _Scripts.Gameplay.Features.Weapon.Factory;
using Entitas;

namespace _Scripts.Gameplay.Features.Backpack.Systems
{
  public class CreateWeaponsSystem : IExecuteSystem
  {
    private readonly IWeaponFactory _weaponFactory;
    private readonly IGroup<GameEntity> _player;
    private readonly List<GameEntity> _buffer = new(1);

    public CreateWeaponsSystem(GameContext gameContext, IWeaponFactory weaponFactory)
    {
      _weaponFactory = weaponFactory;
      _player = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.WeaponHolder
        ));
    }

    public void Execute()
    {
      foreach (var player in _player.GetEntities(_buffer))
      {
        if (player.hasExistingWeapons)
          continue;

        var shotGun = _weaponFactory.CreateWeapon(WeaponTypes.Shotgun, player.WeaponHolder, player.Id);
        var rifle = _weaponFactory.CreateWeapon(WeaponTypes.Rifle, player.WeaponHolder, player.Id);
        var gauss = _weaponFactory.CreateWeapon(WeaponTypes.Gauss, player.WeaponHolder, player.Id);

        player.AddExistingWeapons(new Dictionary<WeaponTypes, int>
        {
          { WeaponTypes.Rifle, rifle.Id },
          { WeaponTypes.Shotgun, shotGun.Id },
          { WeaponTypes.Gauss, gauss.Id }
        });
      }
    }
  }
}