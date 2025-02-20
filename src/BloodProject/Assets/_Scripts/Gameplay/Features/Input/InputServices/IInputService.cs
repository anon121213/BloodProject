using System;
using UnityEngine;

namespace Gameplay.Features.Input.InputServices
{
    public interface IInputService
    {
        Vector3 MoveDirection { get; }
        Vector2 MousePosition { get; }
        Vector2 MouseDelta { get; }
        
        public bool IsShooting { get; }
        public bool IsReloading { get; }

        public bool IsMoving { get; }

        void EnableInput();
        void DisableInput();
    }
}