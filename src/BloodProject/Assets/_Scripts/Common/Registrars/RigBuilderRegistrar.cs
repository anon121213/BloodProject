using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Scripts.Common.Registrars
{
  public class RigBuilderRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private RigBuilder _rigBuilder;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasRigBuilder)
        Entity.AddRigBuilder(_rigBuilder);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveRigBuilder();
  }
}