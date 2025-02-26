using _Scripts.Infrastructure.View.Registrars;
using UnityEditor.Animations;
using UnityEngine;

namespace _Scripts.Common.Registrars.UnityComponents.Animation
{
  public class AnimatorControllerRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Animator _animator;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasAnimatorController) 
        Entity.AddAnimatorController(_animator);
    }

    public override void UnregisterComponents() => 
      Entity.AddAnimatorController(_animator);
  }
}