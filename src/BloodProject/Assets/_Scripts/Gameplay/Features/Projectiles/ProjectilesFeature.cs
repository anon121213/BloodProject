using _Scripts.Gameplay.Features.Projectiles.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Projectiles
{
  public sealed class ProjectilesFeature : Feature
  {
    public ProjectilesFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<SimpleBulletProjectileSystem>());
      Add(systemFactory.Create<ApplyProjectilesEffectOnTargetsSystem>());
    }
  }
}