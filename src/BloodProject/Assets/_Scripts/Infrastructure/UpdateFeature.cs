using _Scripts.Common.Destruct;
using _Scripts.Gameplay.Features.Camera;
using _Scripts.Gameplay.Features.Movement;
using _Scripts.Gameplay.Features.SimpleShootSystem;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using _Scripts.Infrastructure.View;
using Gameplay.Features.Input;
using Gameplay.Features.Player;
using Gameplay.Features.TargetsCollector;

namespace _Scripts.Infrastructure
{
  public class UpdateFeature : Feature
  {
    public UpdateFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<BindViewFeature>());
      Add(systemFactory.Create<InputFeature>());
      Add(systemFactory.Create<PlayerFeature>());
      Add(systemFactory.Create<MovementFeature>());
      Add(systemFactory.Create<CameraFeature>());
      Add(systemFactory.Create<ShootFeature>());
      
      Add(systemFactory.Create<TargetsCollectorFeature>());
      
      Add(systemFactory.Create<ProcessDestructedFeature>());
    }
  }
}