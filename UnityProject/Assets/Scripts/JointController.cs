using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    private void OnJointBreak2D(Joint2D joint)
    {
        GameManager.SubtractScore();
    }
}
