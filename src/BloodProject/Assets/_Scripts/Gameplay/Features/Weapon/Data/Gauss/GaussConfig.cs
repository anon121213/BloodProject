using System.Collections.Generic;
using _Scripts.Gameplay.Features.Effects.Data;
using _Scripts.Gameplay.Features.Weapon.Data.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Gameplay.Features.Weapon.Data.Gauss
{
  [CreateAssetMenu(fileName = "GaussConfig", menuName = "Data/Weapons/GaussConfig")]
  public class GaussConfig : WeaponConfig
  {
    [field: SerializeField] public AssetReferenceGameObject ShootParticle { get; private set; }
    [field: SerializeField] public List<EffectSetup> EffectSetups { get; private set; }
    [field: SerializeField] public float RayDistance { get; private set; }
    [field: SerializeField] public float PushDuration { get; private set; }
    [field: SerializeField] public float PushDistance { get; private set; }
    [field: SerializeField] public LayerMask IgnoreLayers { get; private set; }
  }
}