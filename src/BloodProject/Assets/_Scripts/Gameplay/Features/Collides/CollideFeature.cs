using _Scripts.Gameplay.Features.Collides.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Collides
{
  public sealed class CollideFeature : Feature
  {
    public CollideFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CollideCleanupSystem>());
    }
  }
}