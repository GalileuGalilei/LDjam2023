using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isConnect = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            GameManager.selectedCar = this.gameObject.transform.parent.gameObject;
        }    
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(rb.velocity.magnitude) > 0)
        {
            rb.velocity *= 0.995f;
        }
    }
}
