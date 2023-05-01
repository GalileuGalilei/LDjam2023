using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControler : MonoBehaviour
{

    private LineRenderer lr;
    private Vector2 start, end;

    private void Awake ()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.enabled = false;
    }

    public void SetUpLine ()
    {
        lr.enabled = true;
    }

    public void UpdatePosition (Vector2 start, Vector2 end)
    {
        this.start = start;
        this.end = end;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    public void DisableLine ()
    {
        lr.enabled = false;
    }
}