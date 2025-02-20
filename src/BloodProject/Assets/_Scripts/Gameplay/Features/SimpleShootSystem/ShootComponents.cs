using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.SimpleShootSystem
{
  public class ShootComponents
  {
    [Game] public class Shoot : IComponent { }
    [Game] public class AttackPoint : IComponent { public Transform Value; }
  }
}