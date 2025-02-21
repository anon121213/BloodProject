using _Scripts.Gameplay.Features.Weapon.Data;
using _Scripts.Gameplay.Features.Weapon.Factory;
using Cysharp.Threading.Tasks;
using Entitas;

namespace _Scripts.Gameplay.Features.Player.Systems
{
  public class EquipWeaponSystem : IExecuteSystem
  {
    private readonly IWeaponFactory _weaponFactory;
    private readonly IGroup<GameEntity> _players;

    public EquipWeaponSystem(GameContext gameContext, IWeaponFactory weaponFactory)
    {
      _weaponFactory = weaponFactory;

      _players = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.WeaponHolder,
          GameMatcher.RigBuilder,
          GameMatcher.CurrentWeapon
        ));
    }

    public async void Execute()
    {
      foreach (var player in _players)
      {
        if (player.CurrentWeapon == 0)
        {
          GameEntity weapon = _weaponFactory.CreateWeapon(WeaponTypes.Rifle, player.WeaponHolder);
          player.ReplaceCurrentWeapon(weapon.Id);
          player.RigBuilder.enabled = false;
        }
      }
    }
  }
}