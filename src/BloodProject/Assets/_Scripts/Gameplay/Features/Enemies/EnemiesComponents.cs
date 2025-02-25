using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies
{
  [Game] public class Enemy : IComponent { }
  [Game] public class BehaviourTreeComponent : IComponent { }
  [Game] public class TargetAvailable : IComponent { }
  [Game] public class RootNode : IComponent { public Node Value; }
  [Game] public class CurrentNode : IComponent { public Node Value; }
  [Game] public class CheckPlayerRadius : IComponent { public float Value; }
  [Game] public class DistanceToPatrol : IComponent { public float Value; }
  [Game] public class DistanceToAttackPlayer : IComponent { public float Value; }
  [Game] public class RotateToPlayerSpeed : IComponent { public float Value; }
  [Game] public class TargetsLayerMask : IComponent { public LayerMask Value; }
}