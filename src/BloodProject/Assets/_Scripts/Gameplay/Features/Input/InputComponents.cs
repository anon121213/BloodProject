using Entitas;
using UnityEngine;

namespace Gameplay.Features.Input
{
  [Input] public class Input : IComponent { }
  [Input] public class Shooting : IComponent { }
  [Input] public class Reloading : IComponent { }
  [Input] public class Jumping : IComponent { }
  [Input] public class Dashing : IComponent { }
  [Input] public class MoveInputAxis : IComponent { public Vector3 Value; }
  [Input] public class MouseInputAxis : IComponent { public Vector2 Value; }
  [Input] public class MouseInputDelta : IComponent { public Vector2 Value; }
}