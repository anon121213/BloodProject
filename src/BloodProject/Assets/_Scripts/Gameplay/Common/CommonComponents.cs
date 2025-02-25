using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Gameplay.Common
{
  public class CommonComponents
  {
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class EntityLink : IComponent { [EntityIndex] public int Value; }
  
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class WorldRotation : IComponent { public Quaternion Value; }
  
    [Game] public class Damage : IComponent { public float Value; }
    [Game] public class Active : IComponent { }
 
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }
    [Game] public class CharacterControllerComponent : IComponent { public CharacterController Value; }
    [Game] public class NavMeshAgentComponent : IComponent { public NavMeshAgent Value; }
  }
}