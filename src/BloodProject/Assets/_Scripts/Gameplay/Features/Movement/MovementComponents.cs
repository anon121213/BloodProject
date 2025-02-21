using Entitas;
using UnityEngine;

namespace Gameplay.Features.Movement
{ 
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class MoveSmooth : IComponent { public float Value; }
    [Game] public class Moving : IComponent { }
    [Game] public class MoveByPhysic : IComponent { }
    [Game] public class Teleport : IComponent { }
    [Game] public class Rotate : IComponent { }
    [Game] public class TurnedAlongDirection : IComponent { }
    [Game] public class RotationAlignedAlongDirection : IComponent { }
    [Game] public class MovementAvailable : IComponent { }
}