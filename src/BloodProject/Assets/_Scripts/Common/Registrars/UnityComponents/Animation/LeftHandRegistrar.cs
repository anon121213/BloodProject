using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Scripts.Common.Registrars
{
  public class LeftHandRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private TwoBoneIKConstraint _leftHand;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasLeftHand) 
        Entity.AddLeftHand(_leftHand);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveLeftHand();
  }
}