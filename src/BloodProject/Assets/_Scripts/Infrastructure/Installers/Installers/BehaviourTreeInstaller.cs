using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Nodes;
using VContainer;

namespace _Scripts.Infrastructure.Installers.Installers
{
  public class BehaviourTreeInstaller : MonoInstaller
  {
    public override void Register(IContainerBuilder builder)
    {
      builder.Register<PatrolNode>(Lifetime.Singleton);
      builder.Register<MoveToPlayerNode>(Lifetime.Singleton);
      builder.Register<AttackNode>(Lifetime.Singleton);
    }
  }
}