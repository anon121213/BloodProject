using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class RigidbodyRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Rigidbody _rb;
    
    public override void RegisterComponents() => 
      Entity.AddRigidbody(_rb);

    public override void UnregisterComponents()
    {
      if (Entity.hasRigidbody) 
        Entity.RemoveRigidbody();
    }
  }
}