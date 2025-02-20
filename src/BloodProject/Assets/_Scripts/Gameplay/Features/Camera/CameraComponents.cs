using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Camera
{
  public class CameraComponents
  {
    [Game] public class CameraComponent : IComponent { public UnityEngine.Camera Value; }
    [Game] public class CameraHolder : IComponent { public Transform Value; }
  }
}