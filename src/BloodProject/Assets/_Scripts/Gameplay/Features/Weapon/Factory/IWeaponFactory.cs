using _Scripts.Gameplay.Features.Weapon.Data;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Factory
{
  public interface IWeaponFactory
  {
    GameEntity CreateWeapon(WeaponTypes type, Transform holder);
  }
}