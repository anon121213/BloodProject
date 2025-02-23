using Entitas;
using Knife.RealBlood;
using UnityEngine;

namespace _Scripts.Gameplay.Features.ProjectilesCollides.Systems
{
  public class ProjectilesCollidesBloodHandler : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _projectiles;
    private readonly RaycastHit[] _hit = new RaycastHit[1];

    public ProjectilesCollidesBloodHandler(GameContext gameContext)
    {
      _projectiles = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Projectile,
          GameMatcher.CollideEntityCollider,
          GameMatcher.WorldPosition,
          GameMatcher.Direction,
          GameMatcher.LayerMask,
          GameMatcher.Collide
        ));
    }
    
    public void Execute()
    {
      foreach (var projectile in _projectiles)
      {
        var hittable = projectile.CollideEntityCollider.GetComponent<IHittable>();

        if (hittable != null)
        {
          int results = Physics.RaycastNonAlloc(projectile.Transform.position,
            projectile.Direction, _hit, 3, projectile.LayerMask);

          if (results > 0)
          {
            DamageData data = new DamageData
            {
              point = _hit[0].point,
              normal = _hit[0].normal,
            };

            DamageData[] datas = new DamageData[1];
            datas[0] = data;

            hittable.TakeDamage(datas);
          }
        }
      }
    }
  }
}