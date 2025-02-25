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
    [field: SerializeField] public LayerMask TargetsLayerMask { get; private set; }
  }
}