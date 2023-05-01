using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    private const float GRAPPLE_STRENGTH = 10.0f;

    private FixedJoint2D joint;
    private bool hasJoint;

    public void Retract()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;

        if (joint != null)
        {
            Destroy(joint);
        }

        joint    = null;
        hasJoint = false;

        gameObject.SetActive(false);
    }

    public void Fling(Vector2 from, float angle)
    {
        Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * GRAPPLE_STRENGTH;

        gameObject.SetActive(true);

        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();

        rigidBody2D.isKinematic = false;
        rigidBody2D.position    = from;
        rigidBody2D.AddForce(force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();

#if false
        rigidBody2D.isKinematic     = true;
        rigidBody2D.velocity        = Vector2.zero;
        rigidBody2D.angularVelocity = 0.0f;
#endif

        if (!hasJoint)
        {
            joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = collision.rigidbody;
        }

        hasJoint = true;
    }
}
