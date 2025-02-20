using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Services.Pool
{
    public class ObjectPool : IObjectPool
    {
        private readonly IObjectResolver _objectResolver;
        private readonly Dictionary<GameObject, ObjectPool<GameObject>> _gameObjects = new();

        public ObjectPool(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public T GetGameObject<T>(GameObject prefab, Vector2 position, Quaternion rotation, Transform root)
            where T : MonoBehaviour
        {
            if (!_gameObjects.Keys.Contains(prefab))
                CreatePoolObject(prefab, root, 5);

            GameObject go = _gameObjects[prefab].Get();

            go.transform.position = position;
            go.transform.rotation = rotation;

            return go.GetComponent<T>();
        }
        
        public GameObject GetGameObject(GameObject prefab, Vector2 position, Quaternion rotation, Transform root)
        {
            if (!_gameObjects.Keys.Contains(prefab))
                CreatePoolObject(prefab, root, 5);

            GameObject go = _gameObjects[prefab].Get();

            go.transform.position = position;
            go.transform.rotation = rotation;

            return go;
        }

        public void ReturnGameObject<T>(GameObject tGameObject, T prefab) where T : MonoBehaviour => 
            _gameObjects[prefab.gameObject].Release(tGameObject);

        public void ReturnGameObject(GameObject tGameObject, GameObject mPrefab) => 
            _gameObjects[mPrefab].Release(tGameObject);

        private void CreatePoolObject(GameObject prefab, Transform root, int count)
        {
            GameObject CreateFunc()
            {
                var instance = _objectResolver.Instantiate(prefab, root);
                return instance;
            }

            void ActionOnGet(GameObject tGameObject) => 
                tGameObject.gameObject.SetActive(false);

            void ActionOnRelease(GameObject tGameObject) => 
                tGameObject.gameObject.SetActive(false);

            void ActionOnDestroy(GameObject tGameObject) => 
                Object.Destroy(tGameObject.gameObject);

            _gameObjects[prefab] = new ObjectPool<GameObject>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy,
                defaultCapacity: count);

            var prewarmGameObjects = new List<GameObject>();

            for (var i = 0; i < count; i++)
                prewarmGameObjects.Add(_gameObjects[prefab].Get());

            foreach (var networkObject in prewarmGameObjects)
                _gameObjects[prefab].Release(networkObject);
        }
    }

    public interface IObjectPool
    {
        T GetGameObject<T>(GameObject prefab, Vector2 position, Quaternion rotation, Transform root) where T : MonoBehaviour;
        GameObject GetGameObject(GameObject prefab, Vector2 position, Quaternion rotation, Transform root);
        
        void ReturnGameObject<T>(GameObject tGameObject, T prefab) where T : MonoBehaviour;
        void ReturnGameObject(GameObject tGameObject, GameObject mPrefab);
    }
}