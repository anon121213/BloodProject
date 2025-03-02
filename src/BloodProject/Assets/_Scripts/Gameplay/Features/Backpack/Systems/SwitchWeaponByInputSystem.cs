using Entitas;

namespace _Scripts.Gameplay.Features.Backpack.Systems
{
  public class SwitchWeaponByInputSystem : IExecuteSystem
  {
    private readonly IGroup<InputEntity> _input;
    private readonly IGroup<GameEntity> _entities;

    public SwitchWeaponByInputSystem(GameContext gameContext, InputContext inputContext)
    {
      _input = inputContext.GetGroup(InputMatcher.AllOf(InputMatcher.Input));
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ExistingWeapons
        ));
    }

    public void Execute()
    {
      foreach (var input in _input)
      foreach (var entity in _entities)
      {
        if (!input.isChangeWeapon)
          continue;

        if (!entity.ExistingWeapons.TryGetValue(input.ChangeWeaponType, out int weapon))
          continue;

        entity.isEquipWeapon = true;
        entity.ReplaceEquipWeaponEntity(weapon);
      }
    }
  }
}