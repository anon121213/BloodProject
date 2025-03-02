using _Scripts.Gameplay.Features.Weapon.Data.Base;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Data.Shotgun
{
  [CreateAssetMenu(fileName = "ShotgunConfig", menuName = "Data/Weapons/ShotgunConfig")]
  public class ShotgunConfig : WeaponConfig
  {
    [field: SerializeField] public int PelletCount { get; private set; }
    [field: SerializeField] public float SpredAngleX { get; private set; }
    [field: SerializeField] public float SpredAngleY { get; private set; }
    [field: SerializeField] public float RayDistance { get; private set; }
    [field: SerializeField] public LayerMask IgnoreLayers { get; private set; }
  }
}