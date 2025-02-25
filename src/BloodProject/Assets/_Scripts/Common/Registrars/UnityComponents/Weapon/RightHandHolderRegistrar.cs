using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class RightHandHolderRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Transform _rightHandHolder;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasRightHandHolder) 
        Entity.AddRightHandHolder(_rightHandHolder);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveRightHandHolder();
  }
}