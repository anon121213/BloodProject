using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.ProjectilesCollides
{
  [Game] public class ReadyToCollectTargets : IComponent { }
  [Game] public class Collide : IComponent { }
  [Game] public class CollideEntity : IComponent { public GameEntity Value; }
  [Game] public class CollideEntityCollider : IComponent { public Collider Value; }
  [Game] public class LayerMaskComponent : IComponent { public LayerMask Value; }   
  [Game] public class IgnoreLayers : IComponent { public LayerMask Value; }   
}