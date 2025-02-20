using UnityEngine;

namespace _Scripts.Infrastructure.Services.DontDestroy
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}