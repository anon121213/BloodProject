using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Gravity
{
  [Game] public class Grounded : IComponent { }
  [Game] public class CheckGround : IComponent { }
  [Game] public class Gravity : IComponent { public float Value; }
  [Game] public class GravityVelocity : IComponent { public float Value; }
  [Game] public class CheckGroundRadius : IComponent { public float Value; }
  [Game] public class IgnoreGroundLayers : IComponent { public LayerMask Value; }
}