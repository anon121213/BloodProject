using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class CharacterControllerRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private CharacterController _characterController;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasCharacterController) 
        Entity.AddCharacterController(_characterController);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveCharacterController();
  }
}