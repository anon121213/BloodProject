using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Push
{
  [Game] public class Pushing : IComponent { }
  [Game] public class OnStartPush : IComponent { }
  [Game] public class OnEndPush : IComponent { }
  [Game] public class PushDirection : IComponent { public Vector3 Value; }
  [Game] public class PushDuration : IComponent { public float Value; }
  [Game] public class CurrentPushDuration : IComponent { public float Value; }
  [Game] public class PushDistance : IComponent { public float Value; }
}