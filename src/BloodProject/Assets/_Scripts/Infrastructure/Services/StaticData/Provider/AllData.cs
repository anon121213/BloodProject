﻿using _Scripts.Gameplay.Features.Camera.Data;
using _Scripts.Gameplay.Features.Enemies.Data;
using _Scripts.Gameplay.Features.Player.Data;
using _Scripts.Gameplay.Features.Weapon.Data;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.StaticData.Provider
{
    [CreateAssetMenu(fileName = "AllData", menuName = "Data/AllData")]
    public class AllData : ScriptableObject
    {
        [field: SerializeField] public CameraSettings CameraSettings { get; private set; }
        [field: SerializeField] public PlayerSettings PlayerSettings { get; private set; }
        [field: SerializeField] public WeaponConfigs WeaponConfigs { get; private set; }
        [field: SerializeField] public EnemiesConfigs EnemiesConfigs { get; private set; }
    }
}