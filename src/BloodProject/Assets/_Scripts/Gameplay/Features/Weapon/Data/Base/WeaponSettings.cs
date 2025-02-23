using System;
using _Scripts.Gameplay.Features.Projectiles.Data;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Data.Base
{
  [Serializable]
  public class WeaponSettings
  {
    [field: SerializeField] public int BulletsInClipCount { get; private set; }
    [field: SerializeField] public float ShootDelay { get; private set; }
    [field: SerializeField] public float ReloadDelay { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
  }
}