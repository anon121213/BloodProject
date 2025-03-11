using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Push.Systems
{
  public class PushCharacterControllerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _controllers;
    private readonly List<GameEntity> _buffer = new(1);

    public PushCharacterControllerSystem(GameContext gameContext)
    {
      _controllers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Pushing,
          GameMatcher.CharacterController,
          GameMatcher.PushDirection,
          GameMatcher.PushDuration,
          GameMatcher.CurrentPushDuration,
          GameMatcher.PushDistance,
          GameMatcher.MovementAvailable
        ));
    }

    public void Execute()
    {
      foreach (var controller in _controllers.GetEntities(_buffer))
      {
        if (controller.CurrentPushDuration >= controller.PushDuration) continue;
        
        float pushSpeed = Mathf.Lerp(0, controller.PushDistance / controller.PushDuration,
          1 - (controller.CurrentPushDuration / controller.PushDuration));

        controller.CharacterController.Move(controller.PushDirection * pushSpeed * Time.deltaTime);

        if (!controller.isPushing)
        {
          controller.isOnStartPush = true;
          controller.isPushing = true;
        }

        if (controller.CurrentPushDuration >= controller.PushDuration) 
          controller.isOnEndPush = true;
      }
    }
  }
}