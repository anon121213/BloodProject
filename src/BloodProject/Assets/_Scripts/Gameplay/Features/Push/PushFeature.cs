using _Scripts.Gameplay.Features.Push.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Push
{
  public sealed class PushFeature : Feature
  {
    public PushFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<PushCharacterControllerSystem>());
      Add(systemFactory.Create<PushDurationSystem>());
    }
  }
}