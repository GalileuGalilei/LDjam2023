using UnityEngine;

public class HookLauncherController : MonoBehaviour
{
    void Update()
    {
        Vector2 positionLauncher = new Vector2(transform.position.x, transform.position.y);
        Vector2 positionMouse    = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 banana = positionMouse - positionLauncher;
        float launcherRotation = Mathf.Atan2(banana.y, banana.x);

        Debug.Log($"angle between {positionLauncher} and {positionMouse} is {launcherRotation}");

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Rad2Deg * launcherRotation - 90);
    }
}
