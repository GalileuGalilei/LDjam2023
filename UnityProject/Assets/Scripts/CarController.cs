using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    public bool selected;
    Rigidbody2D rb;
    public bool isConnect = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selected = false;
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(rb.velocity.magnitude) > 0)
        {
            rb.velocity *= 0.995f;
        }
    }
}
