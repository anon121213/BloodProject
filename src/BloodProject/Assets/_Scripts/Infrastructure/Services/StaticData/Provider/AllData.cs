using Gameplay.Features.Camera.Data;
using Gameplay.Features.Player.Data;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.StaticData.Provider
{
    [CreateAssetMenu(fileName = "AllData", menuName = "Data/AllData")]
    public class AllData : ScriptableObject
    {
        [field: SerializeField] public CameraSettings CameraSettings { get; private set; }
        [field: SerializeField] public PlayerSettings PlayerSettings { get; private set; }
    }
}