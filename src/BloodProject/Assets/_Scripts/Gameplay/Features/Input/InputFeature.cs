using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Input.System;

namespace Gameplay.Features.Input
{
  public class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      Add(systems.Create<EmitInputSystem>());
    }
  }
}