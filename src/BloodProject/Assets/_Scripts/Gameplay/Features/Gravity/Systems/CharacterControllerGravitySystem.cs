using _Scripts.Common.Time;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Gravity.Systems
{
  public class CharacterControllerGravitySystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _controllers;

    public CharacterControllerGravitySystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _controllers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CharacterController,
          GameMatcher.Gravity,
          GameMatcher.GravityVelocity
        ));
    }

    public void Execute()
    {
      foreach (var controller in _controllers)
      {
        if (controller.isGrounded)
        {
          controller.ReplaceGravityVelocity(1);
          continue;
        }
        
        float newGravityVelocity = controller.GravityVelocity - controller.Gravity * _timeService.DeltaTime;
        
        Vector3 direction = new Vector3(
          controller.Direction.x, 
          newGravityVelocity,
          controller.Direction.z
        );

        controller.ReplaceDirection(direction);
        controller.ReplaceGravityVelocity(newGravityVelocity);
      }
    }
  }
}