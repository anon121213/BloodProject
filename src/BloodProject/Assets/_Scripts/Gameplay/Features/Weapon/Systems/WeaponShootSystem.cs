using System.Collections.Generic;
using _Scripts.Gameplay.Features.Projectiles.Factory;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
    public class WeaponShootSystem : IExecuteSystem
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly IGroup<GameEntity> _weapons;
        private readonly IGroup<InputEntity> _inputs;
        private readonly IGroup<GameEntity> _camera;
        private readonly List<GameEntity> _buffer = new(1);

        public WeaponShootSystem(GameContext gameContext,
            InputContext inputContext,
            IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;

            _camera = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Camera
                ));

            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.AttackAvailable,
                    GameMatcher.ProjectileData,
                    GameMatcher.AttackPoint
                ));

            _inputs = inputContext.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input
                ));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var camera in _camera)
            foreach (var weapon in _weapons.GetEntities(_buffer))
            {
                if (!weapon.isAttackAvailable || !input.isShooting) 
                    continue;
                
                weapon.isAttack = true;
                Shoot(weapon, camera.Camera);
            }
        }

        private void Shoot(GameEntity weapon, UnityEngine.Camera camera)
        {
            Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));

            float rayDistance = 100f;

            Vector3 direction = ray.GetPoint(rayDistance) - weapon.AttackPoint.position;

            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
                direction = hit.point - weapon.AttackPoint.position;

            _projectileFactory.CreateSimpleBulletProjectile(weapon.ProjectileData, weapon.Id,
                weapon.AttackPoint.position, weapon.Transform.rotation, direction.normalized);
        }

    }
}
