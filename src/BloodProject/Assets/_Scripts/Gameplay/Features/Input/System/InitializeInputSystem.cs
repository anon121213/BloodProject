﻿using Entitas;

namespace _Scripts.Gameplay.Features.Input.System
{
  public class InitializeInputSystem : IInitializeSystem
  {
    public void Initialize() =>
      Contexts.sharedInstance.input.CreateEntity()
        .isInput = true;
  }
}