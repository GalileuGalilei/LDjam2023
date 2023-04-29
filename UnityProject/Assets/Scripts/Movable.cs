using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public float speed = 1f;
    public float maxVelocity = 1f;
    protected float horizontalDirection = 0;

    private Rigidbody2D rb;
    private bool isInGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.right * horizontalDirection * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInGround = true;
        }
    }

    public void SetDirection(float direction)
    {
        this.horizontalDirection = direction;
    }

    public void Jump()
    {
        if(isInGround) 
        {
            rb.AddForce(Vector2.up * GameManager.Instance.gravity * 2f, ForceMode2D.Impulse);
            isInGround = false;
        }
    }
}
