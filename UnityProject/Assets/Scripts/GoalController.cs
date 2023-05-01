using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    public UnityAction OnFinishGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool unconnected = false;
        if(collision.gameObject.tag == "Player")
        {
            OnFinishGame.Invoke();

            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.GetComponent<CarController>() != null)
                {
                    if (!transform.GetChild(i).gameObject.GetComponent<CarController>().isConnect)
                    {
                        unconnected = true;
                    }
                }

                if (unconnected)
                {
                    GameManager.SubtractScore();
                }
            }
        }
    }
}
