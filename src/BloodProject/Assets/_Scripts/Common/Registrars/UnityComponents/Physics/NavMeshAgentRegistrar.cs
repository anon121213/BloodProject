using _Scripts.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Common.Registrars.UnityComponents.Physics
{
  public class NavMeshAgentRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private NavMeshAgent _agent;
    
    public override void RegisterComponents()
    {
      if (!Entity.hasNavMeshAgent) 
        Entity.AddNavMeshAgent(_agent);
    }

    public override void UnregisterComponents() => 
      Entity.RemoveNavMeshAgent();
  }
}