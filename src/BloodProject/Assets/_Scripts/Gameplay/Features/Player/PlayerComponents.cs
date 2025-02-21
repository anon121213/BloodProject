using Entitas;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Scripts.Gameplay.Features.Player
{
  [Game] public class Player : IComponent { }
  [Game] public class Model : IComponent { public Transform Value; }
  [Game] public class LeftHand : IComponent { public TwoBoneIKConstraint Value; }
  [Game] public class RightHand : IComponent { public TwoBoneIKConstraint Value; }
  [Game] public class RigBuilderComponent : IComponent { public RigBuilder Value; }
}