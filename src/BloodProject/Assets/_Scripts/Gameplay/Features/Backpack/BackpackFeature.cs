using _Scripts.Gameplay.Features.Backpack.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Backpack
{
  public sealed class BackpackFeature : Feature
  {
    public BackpackFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<SwitchWeaponByInputSystem>());
      Add(systemFactory.Create<CreateWeaponsSystem>());
    }
  }
}