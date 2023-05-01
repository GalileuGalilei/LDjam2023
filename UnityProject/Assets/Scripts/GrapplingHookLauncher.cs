using UnityEngine;

public class GrapplingHookLauncher: MonoBehaviour
{
    public GrapplingHook grapplingHook;
    public GameObject    grapplingHookFixed;

    private void Start()
    {
        grapplingHookFixed.SetActive(true);
        grapplingHook.Retract();
    }

    void Update()
    {
        Vector2 positionLauncher = new Vector2(transform.position.x, transform.position.y);
        Vector2 positionMouse    = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 banana           = positionMouse - positionLauncher;
        float launcherRotation   = Mathf.Atan2(banana.y, banana.x);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Rad2Deg * launcherRotation - 90);

        if (Input.GetMouseButton(0))
        {
            grapplingHookFixed.SetActive(true);
            grapplingHook.Retract();
        }
        if (Input.GetMouseButtonUp(0))
        {
            grapplingHookFixed.SetActive(false);
            grapplingHook.Fling(grapplingHookFixed.transform.position, launcherRotation);
        }
    }
}
