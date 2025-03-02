using System.Collections.Generic;
using Entitas;
using Knife.RealBlood;
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
    [Game] public class RaycastShooter : IComponent { }
    [Game] public class Shotgun : IComponent { }
    [Game] public class ShotProcessed : IComponent { }
    [Game] public class OwnerID : IComponent { public int Value; }
    [Game] public class AttackPoint : IComponent { public Transform Value; }
    [Game] public class WeaponHolder : IComponent { public Transform Value; }
    [Game] public class RightHandHolder : IComponent { public Transform Value; }
    [Game] public class LeftHandHolder : IComponent { public Transform Value; }
    [Game] public class AttackDelay : IComponent { public float Value; }
    [Game] public class CurrentAttackDelay : IComponent { public float Value; }
    [Game] public class CurrentWeapon : IComponent { public int Value; }
    [Game] public class PelletCount : IComponent { public int Value; }
    [Game] public class SpredAngleX : IComponent { public float Value; }
    [Game] public class SpredAngleY : IComponent { public float Value; }
    [Game] public class RayDistance : IComponent { public float Value; }
    [Game] public class HitPoints : IComponent { public List<Vector3> Value; }
    [Game] public class HitNormals : IComponent { public List<Vector3> Value; }
    [Game] public class Hittables : IComponent { public List<IHittable> Value; }
    [Game] public class HittablesEntities : IComponent { public List<GameEntity> Value; }
    [Game] public class ShootRaycastPosition : IComponent { public List<Vector3> Value; }
    [Game] public class ShootRaycastDirecion : IComponent { public List<Vector3> Value; }
  }
}