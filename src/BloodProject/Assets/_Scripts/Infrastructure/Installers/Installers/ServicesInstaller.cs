using _Scripts.Common.Collisions;
using _Scripts.Common.Physics;
using _Scripts.Common.Time;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Nodes;
using _Scripts.Infrastructure.Services.AssetLoader;
using _Scripts.Infrastructure.Services.Pool;
using _Scripts.Infrastructure.Services.SceneLoader;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using _Scripts.Infrastructure.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Installers.Installers
{
  public class ServicesInstaller : MonoInstaller
  {
    [SerializeField] private AllData _allData;

    public override void Register(IContainerBuilder builder)
    {
      builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
      builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
      builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton).As<ITickable>().As<IFixedTickable>();
      builder.Register<IStaticDataProvider, StaticDataProvider>(Lifetime.Singleton).WithParameter(_allData);
      builder.Register<IObjectPool, ObjectPool>(Lifetime.Singleton);
      builder.Register<ITimeService, UnityTimeService>(Lifetime.Singleton);
      builder.Register<ICollisionRegistry, CollisionRegistry>(Lifetime.Singleton);
      builder.Register<IPhysicsService, PhysicsService>(Lifetime.Singleton);

      builder.Register<PatrolNode>(Lifetime.Singleton);
      builder.Register<MoveToPlayerNode>(Lifetime.Singleton);
    }
  }
}