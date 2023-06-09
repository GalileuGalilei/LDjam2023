using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookControler : MonoBehaviour
{
    public RaycastHit2D hit;

    [SerializeField] LineControler lc;
    [SerializeField] CarController cc;

    void Update()
    {
        if (cc.selected)
        {
            // convert mouse position into world coordinates
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // get direction you want to point at
            Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

            // set vector of transform directly
            transform.up = direction;

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Physics2D.Raycast(transform.position, transform.up, 0);
                lc.DisableLine();
            }
        }

    }

    private void FixedUpdate()
    {
        if (hit)
        {
            Move();
        }

        UpdatePosition();
    }

    private void Shoot ()
    {
        Debug.Log("atira filgo.");
        Ray ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * 1000, Color.cyan);
        hit = Physics2D.Raycast(transform.position, transform.up, 25);
        if(hit)
        {   
            lc.SetUpLine();
        }
        else
        {
            lc.DisableLine();
        }
        Debug.Log(hit);
    }

    private void Move ()
    {
        Rigidbody2D righi = transform.parent.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();
        Vector2 vec = new Vector2(hit.point.x - transform.position.x, hit.point.y - transform.position.y).normalized;
        righi.AddForce(vec * 160);
        lc.UpdatePosition(transform.position, hit.point);
        Debug.DrawRay(transform.position, vec * 15, Color.cyan);
    }

    private void UpdatePosition ()
    {
        transform.position = transform.parent.gameObject.transform.GetChild(0).position + new Vector3(0, 0.45f, 0);
    }
}
