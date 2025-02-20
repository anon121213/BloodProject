using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Features.Camera.Data
{
  [CreateAssetMenu(fileName = "CameraSettings", menuName = "Data/Camera/CameraSettings")]
  public class CameraSettings : ScriptableObject
  {
    [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
    [field: SerializeField] public float MoveByMouseOffset { get; private set; }
  }
}