using _Scripts.Gameplay.Features.Gravity.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Gravity
{
  public sealed class GravityFeature : Feature
  {
    public GravityFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CheckGroundSystem>());
      Add(systemFactory.Create<CharacterControllerGravitySystem>());
    }
  }
}