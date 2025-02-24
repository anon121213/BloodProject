using _Scripts.Gameplay.Features.Input.System;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

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