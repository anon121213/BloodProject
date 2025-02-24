using _Scripts.Gameplay.Features.Camera.Data;
using _Scripts.Gameplay.Features.Player.Data;
using _Scripts.Gameplay.Features.Weapon.Data;

namespace _Scripts.Infrastructure.Services.StaticData.Provider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public StaticDataProvider(AllData allData)
        {
            CameraSettings = allData.CameraSettings;
            PlayerSettings = allData.PlayerSettings;
            WeaponConfigs = allData.WeaponConfigs;
        }

        public CameraSettings CameraSettings { get; }
        public PlayerSettings PlayerSettings { get; }
        public WeaponConfigs WeaponConfigs { get; }
    }

    public interface IStaticDataProvider
    {
        CameraSettings CameraSettings { get; }
        PlayerSettings PlayerSettings { get; }
        WeaponConfigs WeaponConfigs { get; }
    }
}