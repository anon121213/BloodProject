using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Gameplay.Features.Weapon.Data.Base
{
  [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Data/Weapons/WeaponConfig")]
  public class WeaponConfig : ScriptableObject
  {
    [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public WeaponSettings WeaponSettings { get; private set; }
    [field: SerializeField] public WeaponTypes WeaponType { get; private set; }
  }
}