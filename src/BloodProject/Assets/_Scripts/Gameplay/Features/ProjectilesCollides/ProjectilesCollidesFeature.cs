using _Scripts.Gameplay.Features.Collides.Systems;
using _Scripts.Gameplay.Features.ProjectilesCollides.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.ProjectilesCollides
{
  public sealed class ProjectilesCollidesFeature : Feature
  {
    public ProjectilesCollidesFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<ProjectilesCollisionSystem>());
      Add(systemFactory.Create<ProjectilesCollidesBloodHandler>());
      Add(systemFactory.Create<CollideCleanupSystem>());
    }
  }
}