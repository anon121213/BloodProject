using System.Collections.Generic;
using System.Linq;
using _Scripts.Gameplay.Features.Weapon.Data.Base;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Data
{
  [CreateAssetMenu(fileName = "WeaponsConfig", menuName = "Data/Weapons/WeaponsConfig")]
  public class WeaponConfigs : ScriptableObject
  {
    [field: SerializeField] public List<WeaponConfig> Weapons = new();

    public WeaponConfig GetWeaponConfig(WeaponTypes weaponType) => 
      Weapons.FirstOrDefault(x => x.WeaponType == weaponType);
  }

  public enum WeaponTypes
  {
    Rifle = 0
  }
}