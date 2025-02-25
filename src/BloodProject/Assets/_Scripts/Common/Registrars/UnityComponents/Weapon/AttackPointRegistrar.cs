using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class AttackPointRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Transform _attackPoint;
    
    public override void RegisterComponents()
    {
      Entity.AddAttackPoint(_attackPoint);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasAttackPoint) 
        Entity.RemoveAttackPoint();
    }
  }
}