using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Scripts.Common.Registrars
{
  public class RightHandRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private TwoBoneIKConstraint _rightHand;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasRightHand) 
        Entity.AddRightHand(_rightHand);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveRightHand();
  }
}