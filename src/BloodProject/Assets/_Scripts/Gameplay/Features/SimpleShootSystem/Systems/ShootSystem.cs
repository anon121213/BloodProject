using System.Collections.Generic;
using Entitas;
using Knife.RealBlood;
using UnityEngine;

namespace _Scripts.Gameplay.Features.SimpleShootSystem.Systems
{
  public class ShootSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly List<GameEntity> _buffer = new(1);

    public ShootSystem(GameContext gameContext)
    {
      _players = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.Camera,
          GameMatcher.Shoot
        ));
    }

    public void Execute()
    {
      foreach (var player in _players.GetEntities(_buffer))
      {
        player.isShoot = false;
        Shoot(player.Camera);
      }
    }

    private void Shoot(UnityEngine.Camera camera)
    {
      Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
      Ray ray = camera.ScreenPointToRay(screenCenter);
    
      if (Physics.Raycast(ray, out RaycastHit hit, 100, LayerMask.GetMask("Enemy")))
      {
        if (hit.collider.TryGetComponent(out IHittable hitBox))
        {
          DamageData[] damageDatas = new DamageData[1];

          damageDatas[0] = new DamageData
          {
            amount = 30,
            point = hit.point,
            normal = hit.normal,
            direction = ray.direction
          };

          hitBox.TakeDamage(damageDatas);
        }
      }
    }
  }
}