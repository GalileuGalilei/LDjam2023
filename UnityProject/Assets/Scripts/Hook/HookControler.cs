using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookControler : MonoBehaviour
{
    public RaycastHit2D hit;
    [SerializeField] LineControler lc;

    void FixedUpdate ()
    {
        Debug.Log(GameManager.selectedCar.name);
        if(GameManager.selectedCar == this.transform.parent.gameObject)
        {
            // convert mouse position into world coordinates
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
            // get direction you want to point at
            Vector2 direction = (mouseScreenPosition - (Vector2) transform.position).normalized;
    
            // set vector of transform directly
            transform.up = direction;

            if(Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            if(hit)
            {
                Move();
            }
        }
        UpdatePosition();
    }

    private void Shoot ()
    {
        Ray ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * 1000, Color.cyan);
        hit = Physics2D.Raycast(transform.position, transform.up, 10);
        if(hit)
        {   
            lc.SetUpLine();
        }
        else
        {
            lc.DisableLine();
        }
    }

    private void Move ()
    {
        Rigidbody2D righi = transform.parent.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();
        Vector2 vec = new Vector2(hit.point.x - transform.position.x, hit.point.y - transform.position.y).normalized;
        righi.AddForce(vec * 130);
        lc.UpdatePosition(transform.position, hit.point);
        Debug.DrawRay(transform.position, vec * 10, Color.cyan);
    }

    private void UpdatePosition ()
    {
        transform.position = transform.parent.gameObject.transform.GetChild(0).position + new Vector3(0, 0.45f, 0);
    }
}
