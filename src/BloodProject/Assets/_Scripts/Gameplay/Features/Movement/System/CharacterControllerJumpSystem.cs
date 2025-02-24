using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Movement.System
{
  public class CharacterControllerJumpSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _controllers;
    private readonly IGroup<InputEntity> _input;
    private readonly List<GameEntity> _buffer = new(1);

    public CharacterControllerJumpSystem(GameContext gameContext, InputContext inputContext)
    {
      _controllers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CharacterController,
          GameMatcher.Direction,
          GameMatcher.JumpAvailable,
          GameMatcher.JumpForce,
          GameMatcher.GravityVelocity,
          GameMatcher.Grounded
        ));

      _input = inputContext.GetGroup(InputMatcher
        .AllOf(InputMatcher.Input));
    }

    public void Execute()
    {
      foreach (var input in _input)
      foreach (var controller in _controllers.GetEntities(_buffer))
      {
        if (!input.isJumping || !controller.isGrounded) 
          continue;

        float jumpVelocity = Mathf.Sqrt(2f * controller.JumpForce * Mathf.Abs(controller.GravityVelocity));

        Vector3 direction = new Vector3(
          controller.Direction.x, 
          jumpVelocity, 
          controller.Direction.z
        );
        
        controller.ReplaceDirection(direction);
        controller.ReplaceGravityVelocity(jumpVelocity);
      }
    }
  }
}