using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Infrastructure.Services.AssetLoader
{
    public interface IAssetProvider
    {
        T LoadAsset<T>(string path) where T : Component;
        UniTask<T> LoadAsync<T>(string address) where T : class;
        UniTask<T> LoadAsync<T>(AssetReference assetReference) where T : Component;
        UniTask<GameObject> LoadAsync(AssetReference assetReference);
        UniTask<List<T>> LoadAssetsByLabelAsync<T>(string label) where T : class;
        void Cleanup();
    }
}