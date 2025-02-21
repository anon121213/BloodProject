using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon
{
  public class WeaponComponents
  {
    [Game] public class Weapon : IComponent { }
    [Game] public class Shoot : IComponent { }
    [Game] public class Shooter : IComponent { }
    [Game] public class ShootAvailable : IComponent { }
    [Game] public class OnShootDelay : IComponent { }
    [Game] public class AttackPoint : IComponent { public Transform Value; }
    [Game] public class WeaponHolder : IComponent { public Transform Value; }
    [Game] public class RightHandHolder : IComponent { public Transform Value; }
    [Game] public class LeftHandHolder : IComponent { public Transform Value; }
    [Game] public class ShootDelay : IComponent { public float Value; }
    [Game] public class CurrentShootDelay : IComponent { public float Value; }
    [Game] public class CurrentWeapon : IComponent { public int Value; }
  }
}