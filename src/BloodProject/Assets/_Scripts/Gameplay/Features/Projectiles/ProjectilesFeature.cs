using _Scripts.Gameplay.Features.Projectiles.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Projectiles.Systems;

namespace _Scripts.Gameplay.Features.Projectiles
{
  public class ProjectilesFeature : Feature
  {
    public ProjectilesFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<SimpleBulletProjectileSystem>());
      Add(systemFactory.Create<ApplyProjectilesEffectOnTargetsSystem>());
      Add(systemFactory.Create<ProjectilesDeathProcessingSystem>());
    }
  }
}