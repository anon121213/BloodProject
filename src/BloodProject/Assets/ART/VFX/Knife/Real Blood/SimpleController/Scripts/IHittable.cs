using System.Collections;
using System.Collections.Generic;
using _Scripts.Gameplay.Features.Blood.Data;

namespace Knife.RealBlood
{
    /// <summary>
    /// Simple Hittable object interface
    /// </summary>
    public interface IHittable
    {
        void TakeDamage(DamageData[] damage);
    }
}