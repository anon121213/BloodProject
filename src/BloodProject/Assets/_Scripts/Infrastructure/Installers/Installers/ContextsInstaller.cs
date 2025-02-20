using VContainer;

namespace _Scripts.Infrastructure.Installers.Installers
{
  public class ContextsInstaller : MonoInstaller
  {
    public override void Register(IContainerBuilder container)
    {
      container.RegisterInstance(Contexts.sharedInstance);
      container.RegisterInstance(Contexts.sharedInstance.game);
      container.RegisterInstance(Contexts.sharedInstance.input);
    }
  }
}