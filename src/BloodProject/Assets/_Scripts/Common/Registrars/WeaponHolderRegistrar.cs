using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class WeaponHolderRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Transform _weaponHolder;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasWeaponHolder) 
        Entity.AddWeaponHolder(_weaponHolder);  
    }

    public override void UnregisterComponents() => 
      Entity.RemoveWeaponHolder();
  }
}