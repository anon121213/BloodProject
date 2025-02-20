using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Features.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Player/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; }
        [field: SerializeField] public Vector2 SpawnPosition { get; private set; }
        [field: SerializeField] public float MoveSmooth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public int InitHealth { get; private set; }
    }
}