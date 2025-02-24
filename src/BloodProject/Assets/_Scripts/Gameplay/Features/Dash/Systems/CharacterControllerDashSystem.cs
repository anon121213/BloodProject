using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Dash.Systems
{
  public class CharacterControllerDashSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _controllers;
    private readonly IGroup<InputEntity> _input;
    private readonly List<GameEntity> _buffer = new(1);

    public CharacterControllerDashSystem(GameContext gameContext, InputContext inputContext)
    {
      _controllers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CharacterController,
          GameMatcher.Direction,
          GameMatcher.MovementAvailable,
          GameMatcher.DashDistance,
          GameMatcher.DashDuration,
          GameMatcher.CurrentDashDuration,
          GameMatcher.DashAvailable
        ));

      _input = inputContext.GetGroup(InputMatcher
        .AllOf(InputMatcher.Input));
    }

    public void Execute()
    {
      foreach (var input in _input)
      foreach (var controller in _controllers.GetEntities(_buffer))
      {
        if (!input.isDashing || controller.isOnDashCooldown
            && controller.CurrentDashDuration >= controller.DashDuration ) continue;
        
        float dashSpeed = Mathf.Lerp(0, controller.DashDistance / controller.DashDuration,
          1 - (controller.CurrentDashDuration / controller.DashDuration));

        controller.CharacterController.Move(controller.Direction * dashSpeed * Time.deltaTime);

        if (!controller.isDashing)
        {
          controller.isOnStartDash = true;
          controller.isDashing = true;
        }

        if (controller.CurrentDashDuration >= controller.DashDuration)
        {
          controller.isOnEndDash = true;
          controller.isOnDashCooldown = true;
        }
      }
    }
  }
}