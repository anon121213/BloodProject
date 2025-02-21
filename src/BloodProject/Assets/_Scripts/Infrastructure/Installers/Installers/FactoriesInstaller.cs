using _Scripts.Gameplay.Features.Projectiles.Factory;
using _Scripts.Gameplay.Features.Weapon.Factory;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using _Scripts.Infrastructure.StateMachine.Factory;
using _Scripts.Infrastructure.View.Factory;
using Gameplay.Features.Player.Factory;
using VContainer;

namespace _Scripts.Infrastructure.Installers.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<IStateFactory, StateFactory>(Lifetime.Singleton);
            builder.Register<ISystemFactory, SystemFactory>(Lifetime.Singleton);
            builder.Register<IEntityViewFactory, EntityViewFactory>(Lifetime.Singleton);
            builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
            builder.Register<IProjectileFactory, ProjectileFactory>(Lifetime.Singleton);
            builder.Register<IWeaponFactory, WeaponFactory>(Lifetime.Singleton);
        }
    }
}