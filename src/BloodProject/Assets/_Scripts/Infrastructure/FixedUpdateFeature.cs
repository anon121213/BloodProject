﻿using _Scripts.Gameplay.Features.Gravity;
using _Scripts.Gameplay.Features.Movement;
using _Scripts.Gameplay.Features.Projectiles;
using _Scripts.Gameplay.Features.ProjectilesCollides;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace _Scripts.Infrastructure
{
  public sealed class FixedUpdateFeature : Feature
  {
    public FixedUpdateFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<PhysicsMovementFeature>());
      Add(systemFactory.Create<ProjectilesCollidesFeature>());
      Add(systemFactory.Create<ProjectilesFeature>());
    }
  }
}