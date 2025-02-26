using _Scripts.Gameplay.Features.Enemies.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Enemies
{
  public sealed class EnemiesFeature : Feature
  {
    public EnemiesFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<BehaviourTreeSystem>());
      Add(systemFactory.Create<EnemyWalkAnimationSystem>());
      Add(systemFactory.Create<EnemyAttackAnimationSystem>());
    }
  }
}