using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            GameManager.selectedCar = this.gameObject.transform.parent.gameObject;
        }    
    }
}
