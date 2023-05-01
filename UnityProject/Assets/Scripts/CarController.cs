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

    private void FixedUpdate()
    {
        if(Mathf.Abs(rb.velocity.magnitude) > 0)
        {
            rb.velocity *= 0.995f;
        }

        Collider2D collider = gameObject.GetComponent<Collider2D>();
        if (collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                GameManager.selectedCar = this.gameObject.transform.parent.gameObject;
                Debug.Log("Selected car: " + GameManager.selectedCar.name);
            }
        }
    }
}
