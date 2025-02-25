using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.Data
{
  [CreateAssetMenu(menuName = "Data/Enemies/EnemiesConfigs", fileName = "EnemiesConfigs")]
  public class EnemiesConfigs : ScriptableObject
  {
    [SerializeField] private List<EnemySetup> Configs = new();

    public EnemyConfig GetEnemyConfig(EnemyType type) => 
      Configs.FirstOrDefault(x => x.Type == type).Config;
  }

  [Serializable]
  public struct EnemySetup
  {
    public EnemyConfig Config;
    public EnemyType Type;
  }

  public enum EnemyType
  {
    Unknown = 0,
    SimpleEnemy = 1
  }
}