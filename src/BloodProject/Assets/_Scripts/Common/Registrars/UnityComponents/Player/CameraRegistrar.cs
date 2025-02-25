using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class CameraRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraHolder;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasCamera)
      {
        Entity.AddCameraHolder(_cameraHolder);
        Entity.AddCamera(_camera);
      } 
    }

    public override void UnregisterComponents()
    {
      Entity.RemoveCameraHolder();
      Entity.RemoveCamera();
    }
  }
}