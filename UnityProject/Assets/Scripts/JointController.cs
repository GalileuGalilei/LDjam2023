using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    private void OnJointBreak2D(Joint2D joint)
    {
        GameManager.SubtractScore();

        Transform f = transform.parent;
        for(int i = 0; i < f.childCount; i++)
        {
            if(f.GetChild(i).gameObject.GetComponent<CarController>() != null)
            {
                f.GetChild(i).gameObject.GetComponent<CarController>().isConnect = false;
            }
        }
    }
}
