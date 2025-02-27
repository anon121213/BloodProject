﻿using _Scripts.Common.Destruct;
using _Scripts.Gameplay.Features.Camera;
using _Scripts.Gameplay.Features.Dash;
using _Scripts.Gameplay.Features.Effects;
using _Scripts.Gameplay.Features.Enemies;
using _Scripts.Gameplay.Features.Input;
using _Scripts.Gameplay.Features.Movement;
using _Scripts.Gameplay.Features.Player;
using _Scripts.Gameplay.Features.Projectiles;
using _Scripts.Gameplay.Features.Weapon;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using _Scripts.Infrastructure.View;

namespace _Scripts.Infrastructure
{
  public sealed class UpdateFeature : Feature
  {
    public UpdateFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<BindViewFeature>());
      Add(systemFactory.Create<InputFeature>());
      Add(systemFactory.Create<PlayerFeature>());
      Add(systemFactory.Create<MovementFeature>());
      Add(systemFactory.Create<CameraFeature>());
      Add(systemFactory.Create<WeaponFeature>());
      Add(systemFactory.Create<DashFeature>());
      Add(systemFactory.Create<EnemiesFeature>());
      Add(systemFactory.Create<EffectsFeature>());
      
      Add(systemFactory.Create<ProcessDestructedFeature>());
    }
  }
}