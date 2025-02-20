using _Scripts.Gameplay.Features.Camera.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Gameplay.Features.Camera
{
  public class CameraFeature : Feature
  {
    public CameraFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<CameraRotateByMouseSystem>());
    }
  }
}