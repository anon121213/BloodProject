using _Scripts.Gameplay.Features.Player.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Player
{
  public sealed class PlayerFeature : Feature
  {
    public PlayerFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<SetPlayerInputDirectionSystem>());
      Add(systemFactory.Create<EquipWeaponSystem>());
      Add(systemFactory.Create<SetArmOnHoldersSystem>());
    }
  }
}