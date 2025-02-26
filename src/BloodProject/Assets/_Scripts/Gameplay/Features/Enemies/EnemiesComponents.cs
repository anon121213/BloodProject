using System.Collections.Generic;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using Entitas;
using Gameplay.Features.Effects.Data;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies
{
  [Game] public class Enemy : IComponent { }
  [Game] public class BehaviourTreeComponent : IComponent { }
  [Game] public class TargetAvailable : IComponent { }
  [Game] public class Patrol : IComponent { }
  [Game] public class AttackCombo : IComponent { public int Value; }
  [Game] public class MaxAttackCombo : IComponent { public int Value; }
  [Game] public class AttackRadiusComponent : IComponent { public float Value; }
  [Game] public class AttackEffects : IComponent { public List<EffectSetup> Value; }
  [Game] public class RootNode : IComponent { public Node Value; }
  [Game] public class CurrentNode : IComponent { public Node Value; }
  [Game] public class CheckPlayerRadius : IComponent { public float Value; }
  [Game] public class DistanceToPatrol : IComponent { public float Value; }
  [Game] public class DistanceToAttackPlayer : IComponent { public float Value; }
  [Game] public class RotateToPlayerSpeed : IComponent { public float Value; }
  [Game] public class TargetsLayerMask : IComponent { public LayerMask Value; }
}