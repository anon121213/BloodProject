using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars.UnityComponents.Physics
{
  public class RigidbodyRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private bool _isDiscreteMovement;
    
    public override void RegisterComponents()
    {
      Entity.AddRigidbody(_rb);
      Entity.isDiscreteRbMovement = _isDiscreteMovement;
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasRigidbody) 
        Entity.RemoveRigidbody();
    }
  }
}