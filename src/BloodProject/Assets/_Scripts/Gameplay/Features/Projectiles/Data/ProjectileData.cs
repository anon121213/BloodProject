using System;
using System.Collections.Generic;
using Gameplay.Features.Effects.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Gameplay.Features.Projectiles.Data
{
  [Serializable]
  public struct ProjectileData
  {
    public AssetReferenceGameObject Prefab;
    public List<EffectSetup> EffectSetups;
    public float Speed;
    public float LifeTime;
    public float Pierce;
    public float CollisionRadius;
    public float CheckCollisionInterval;
    public LayerMask CollisionLayerMask;
  }
}