using System.Collections.Generic;
using _Scripts.Gameplay.Features.Weapon.Data;
using Entitas;

namespace _Scripts.Gameplay.Features.Backpack
{
  [Game] public class EquipWeapon : IComponent { }
  [Game] public class ExistingWeapons : IComponent { public Dictionary<WeaponTypes, int> Value; }
  [Game] public class EquipWeaponEntity : IComponent { public int Value; }
  [Game] public class CurrentWeapon : IComponent { public int Value; }

}