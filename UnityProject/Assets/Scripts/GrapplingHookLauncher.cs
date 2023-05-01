using UnityEngine;

public class GrapplingHookLauncher: MonoBehaviour
{
    public GrapplingHook grapplingHook;
    public GameObject    grapplingHookFixed;

    private Rigidbody2D     mountPoint;
    private DistanceJoint2D joint;

    public void Tie()
    {
        mountPoint = gameObject.AddComponent<Rigidbody2D>();
        joint      = gameObject.AddComponent<DistanceJoint2D>();

        joint.connectedBody = grapplingHook.GetComponent<Rigidbody2D>();
    }

    private void Untie()
    {
        if (joint != null)
        {
            Destroy(joint);
            joint = null;
        }

        if (mountPoint != null)
        {
            Destroy(mountPoint);
            mountPoint = null;
        }
    }

    private void Start()
    {
        Untie();
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
            Untie();
        }

        if (Input.GetMouseButtonUp(0))
        {
            grapplingHookFixed.SetActive(false);
            grapplingHook.Fling(grapplingHookFixed.transform.position, launcherRotation);
        }

        if (joint != null)
        {
            joint.distance -= Time.deltaTime * 2.5f;

            if (joint.distance < 1.0f)
            {
                joint.distance = 1.0f;
            }
        }
    }
}
