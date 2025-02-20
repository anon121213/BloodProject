using UnityEngine;

namespace _Scripts.Infrastructure.Tools
{
  public class PerformanceStatsWindow : MonoBehaviour
  {
    private bool showWindow = true;
    private Rect windowRect = new Rect(10, 10, 250, 150);

    private float deltaTime = 0.0f;
    private float memoryUsage;
    private int objectCount;

    private void Awake() => 
      DontDestroyOnLoad(this);

    private void Update()
    {
      deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

      memoryUsage = System.GC.GetTotalMemory(false) / (1024 * 1024);

      objectCount = FindObjectsByType<GameObject>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Length;

      if (Input.GetKeyDown(KeyCode.F1)) 
        showWindow = !showWindow;
    }

    private void OnGUI()
    {
      if (showWindow)
      {
        windowRect = GUI.Window(0, windowRect, DrawWindow, "Performance Stats");
      }
    }

    private void DrawWindow(int windowID)
    {
      GUILayout.Label($"FPS: {1.0f / deltaTime:0.}");
      GUILayout.Label($"Memory Usage: {memoryUsage:0.0} MB");
      GUILayout.Label($"Object Count: {objectCount}");

      GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
    }
  }
}