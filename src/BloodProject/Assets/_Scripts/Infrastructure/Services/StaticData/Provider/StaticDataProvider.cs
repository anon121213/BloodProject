using Gameplay.Features.Camera.Data;
using Gameplay.Features.Player.Data;

namespace _Scripts.Infrastructure.Services.StaticData.Provider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(AllData allData)
        {
            CameraSettings = allData.CameraSettings;
            PlayerSettings = allData.PlayerSettings;
        }

        public CameraSettings CameraSettings { get; }
        public PlayerSettings PlayerSettings { get; }
    }

    public interface IStaticDataProvider
    {
        CameraSettings CameraSettings { get; }
        PlayerSettings PlayerSettings { get; }
    }
}