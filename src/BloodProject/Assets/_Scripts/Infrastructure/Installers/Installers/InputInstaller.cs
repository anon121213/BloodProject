using _Scripts.Gameplay.Features.Input.InputServices;
using _Scripts.Gameplay.Features.Input.InputServices.PC;
using VContainer;

namespace _Scripts.Infrastructure.Installers.Installers
{
  public class InputInstaller : MonoInstaller
  {
    public override void Register(IContainerBuilder builder)
    {
      builder.Register<IInputService, PCInputService>(Lifetime.Singleton);
    }
  }
}