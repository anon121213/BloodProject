using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class leftHandHolderRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Transform _leftHandHolder;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasLeftHandHolder) 
        Entity.AddLeftHandHolder(_leftHandHolder);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveLeftHandHolder();
  }
}