using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Player
{
  [Game] public class Player : IComponent { }
  [Game] public class Model : IComponent { public Transform Value; }
}