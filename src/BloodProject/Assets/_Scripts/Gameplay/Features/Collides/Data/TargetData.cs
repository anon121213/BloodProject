using UnityEngine;

namespace Gameplay.Features.TargetsCollector.Data
{
  [CreateAssetMenu(menuName = "Data/Targets/TargetData", fileName = "TargetData")]
  public class TargetData : ScriptableObject
  {
    [field: SerializeField] public float Radius { get; private set; }
    [field: SerializeField] public float TargetsLimit { get; private set; }
    [field: SerializeField] public float CollectTargetsInterval { get; private set; }
    [field: SerializeField] public LayerMask LayerMask { get; private set; }
  }
}