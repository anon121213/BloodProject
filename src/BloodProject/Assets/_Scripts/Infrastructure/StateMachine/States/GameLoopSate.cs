using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using _Scripts.Infrastructure.StateMachine.StateInfrastructure;
using UnityEngine;

namespace _Scripts.Infrastructure.StateMachine.States
{
  public class GameLoopState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private UpdateFeature _updateFeature;
    private FixedUpdateFeature _fixedUpdateFeature;

    public GameLoopState(ISystemFactory systems, GameContext gameContext)
    {
      _systems = systems;
      _gameContext = gameContext;
    }
    
    public override void Enter()
    {
      Debug.Log(_systems);
      _updateFeature = _systems.Create<UpdateFeature>();
      _fixedUpdateFeature = _systems.Create<FixedUpdateFeature>();
      _fixedUpdateFeature.Initialize();
      _updateFeature.Initialize();
    }

    protected override void OnUpdate()
    {
      _updateFeature.Execute();
      _updateFeature.Cleanup();
    }

    protected override void OnFixedUpdate()
    {
      _fixedUpdateFeature.Execute();
      _fixedUpdateFeature.Cleanup();
    }

    protected override void ExitOnEndOfFrame()
    {
      _updateFeature.DeactivateReactiveSystems();
      _updateFeature.ClearReactiveSystems();

      DestructEntities();
      
      _updateFeature.Cleanup();
      _updateFeature.TearDown();
      _updateFeature = null;
      
      _fixedUpdateFeature.Cleanup();
      _fixedUpdateFeature.TearDown();
      _updateFeature = null;
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;
    }
  }
}