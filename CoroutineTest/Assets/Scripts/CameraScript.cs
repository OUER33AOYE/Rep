using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    private void Update()
    {
        transform.position = Player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y,-10f);
    }
}
