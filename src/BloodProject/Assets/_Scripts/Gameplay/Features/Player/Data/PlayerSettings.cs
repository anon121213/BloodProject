using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Gameplay.Features.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Player/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
        [field: SerializeField] public Vector3 SpawnPosition { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public float Gravity { get; private set; }
        [field: SerializeField] public float DashDistance { get; private set; }
        [field: SerializeField] public float DashDuration { get; private set; }
        [field: SerializeField] public float DashCooldown { get; private set; }
        [field: SerializeField] public float CheckGroundRadius { get; private set; }
        [field: SerializeField] public LayerMask IgnoreGroundLayers { get; private set; }
        [field: SerializeField] public int InitHealth { get; private set; }
    }
}