using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Installers
{
    public class CompositeInstaller : LifetimeScope
    {
        [SerializeField] private List<MonoInstaller> _monoInstallers = new(); 

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrapper.Bootstrapper>().AsSelf();
            
            foreach (var installer in _monoInstallers) 
                installer.Register(builder);
        }
    }
    
    public class MonoInstaller : MonoBehaviour
    {
        public virtual void Register(IContainerBuilder builder) { }
    }
}
