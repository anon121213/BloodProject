using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Input.System;

namespace _Scripts.Gameplay.Features.Input
{
  public sealed class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      Add(systems.Create<EmitInputSystem>());
    }
  }
}