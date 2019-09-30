using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    float t = 0f;
    void Update()
    {
        t += Time.deltaTime;
        if(t>3)
        {
            Destroy(gameObject);
        } 
    }
}
