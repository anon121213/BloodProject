using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon
{
  public class WeaponComponents
  {
    [Game] public class Weapon : IComponent { }
    [Game] public class Attack : IComponent { }
    [Game] public class Attacker : IComponent { }
    [Game] public class AttackAvailable : IComponent { }
    [Game] public class OnAttackDelay : IComponent { }
    [Game] public class AttackPoint : IComponent { public Transform Value; }
    [Game] public class WeaponHolder : IComponent { public Transform Value; }
    [Game] public class RightHandHolder : IComponent { public Transform Value; }
    [Game] public class LeftHandHolder : IComponent { public Transform Value; }
    [Game] public class AttackDelay : IComponent { public float Value; }
    [Game] public class CurrentAttackDelay : IComponent { public float Value; }
    [Game] public class CurrentWeapon : IComponent { public int Value; }
  }
}