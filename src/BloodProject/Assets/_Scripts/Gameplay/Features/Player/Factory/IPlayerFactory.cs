using UnityEngine;

namespace Gameplay.Features.Player.Factory
{
    public interface IPlayerFactory
    {
        GameEntity CreatePlayer(Vector2 position);
    }
}