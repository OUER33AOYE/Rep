using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UserTouchPad : MonoBehaviour
{
    public GameObject PopupPrefab;
    private void OnMouseDown()
    {
        Vector3 xy = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        xy.z = 0;
        PopupScript.Create(xy,Random.Range(10,100) * Random.Range(3,10), PopupPrefab);
    }
   
}
