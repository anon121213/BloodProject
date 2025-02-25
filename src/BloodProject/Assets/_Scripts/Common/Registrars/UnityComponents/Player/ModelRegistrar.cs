using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;

namespace _Scripts.Common.Registrars
{
  public class ModelRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private Transform _model; 
    
    public override void RegisterComponents()
    {
      if (!Entity.hasModel) 
        Entity.AddModel(_model);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveModel();
  }
}