using System.Collections.Generic;
using Gameplay.Features.Effects.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Gameplay.Features.Projectiles.Data
{
  [CreateAssetMenu(menuName = "Data/Projectiles/ProjectileConfig", fileName = "ProjectileConfig")]
  public class ProjectileConfig : ScriptableObject
  {
    public AssetReferenceGameObject Prefab;
    public List<EffectSetup> EffectSetups;
    public float Speed;
    public float LifeTime;
    public LayerMask CollisionLayerMask;
  }
}