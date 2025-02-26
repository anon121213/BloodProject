using System.Collections.Generic;
using Gameplay.Features.Effects.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Gameplay.Features.Enemies.Data
{
  public abstract class EnemyConfig : ScriptableObject
  {
    [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float RotateToPlayerSpeed { get; private set; }
    [field: SerializeField] public float CheckPlayerRadius { get; private set; }
    [field: SerializeField] public float DistanceToPatrol { get; private set; }
    [field: SerializeField] public float DistanceToAttackPlayer { get; private set; }
    [field: SerializeField] public float AttackRadius { get; private set; }
    [field: SerializeField] public float AttackDelay { get; private set; }
    [field: SerializeField, Range(0, 5)] public int MaxAttackCombo { get; private set; }
    [field: SerializeField] public List<EffectSetup> AttackEffects { get; private set; }
    [field: SerializeField] public LayerMask TargetsLayerMask { get; private set; }
  }
}