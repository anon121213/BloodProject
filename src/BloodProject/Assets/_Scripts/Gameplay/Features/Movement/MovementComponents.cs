using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Movement
{ 
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class JumpForce : IComponent { public float Value; }
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class LastWorldPosition : IComponent { public Vector3 Value; }
    [Game] public class NavMashTargetPosition : IComponent { public Vector3 Value; }
    [Game] public class Moving : IComponent { }
    [Game] public class Jumping : IComponent { }
    [Game] public class MoveByPhysic : IComponent { }
    [Game] public class MoveByNavMesh : IComponent { }
    [Game] public class DiscreteRbMovement : IComponent { }
    [Game] public class Teleport : IComponent { }
    [Game] public class Rotate : IComponent { }
    [Game] public class TurnedAlongDirection : IComponent { }
    [Game] public class RotationAlignedAlongDirection : IComponent { }
    [Game] public class MovementAvailable : IComponent { }
    [Game] public class JumpAvailable : IComponent { }
}