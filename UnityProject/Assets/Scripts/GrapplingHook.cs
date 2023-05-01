using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    private const float GRAPPLE_STRENGTH = 10.0f;

    public void Retract()
    {
        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().isKinematic = true;
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
}
