using _Scripts.Gameplay.Features.Weapon.Data;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Input.InputServices
{
    public interface IInputService
    {
        Vector3 MoveDirection { get; }
        Vector2 MousePosition { get; }
        Vector2 MouseDelta { get; }
        
        public bool IsShooting { get; }
        public bool IsReloading { get; }

        public bool IsMoving { get; }
        public bool IsJumping { get; }
        public bool IsDashing { get; }

        public bool IsChangeWeapon { get; }
        public WeaponTypes ChangeWeaponType { get; }

        void EnableInput();
        void DisableInput();
    }
}