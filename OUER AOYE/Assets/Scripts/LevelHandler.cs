using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    Vector2 FirstTouch, FirstMouseClick;
    Rigidbody StandRB;
    Transform StandTr;
    public bool Control;
    private void Start()
    {
        Control = true;
        Input.simulateMouseWithTouches = true;
        StandRB = transform.Find("Stand").GetComponent<Rigidbody>();
        FirstTouch = new Vector2();
    }
    private void FixedUpdate()
    {
        if (Control)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    FirstTouch = touch.position;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    RotateStand(new Vector2(touch.position.x - FirstTouch.x, touch.position.y - FirstTouch.y));
                }
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {              
               StandRB.rotation *= Quaternion.AngleAxis(0.7f, Vector3.right);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                StandRB.rotation *= Quaternion.AngleAxis(-0.7f, Vector3.right);
            }
            if(Input.GetKey(KeyCode.W))
            {
                StandRB.rotation *= Quaternion.AngleAxis(0.7f, Vector3.forward);
            }
            if (Input.GetKey(KeyCode.S))
            {
                StandRB.rotation *= Quaternion.AngleAxis(-0.7f, Vector3.forward);
            }
        }
    }
    void RotateStand(Vector2 Direction)
    {
        if (Mathf.Abs(Direction.x) > Mathf.Abs(Direction.y))
        {
            if (Direction.x > 0)
            {
                StandRB.rotation *= Quaternion.AngleAxis(0.7f, Vector3.right);
            }
            else
            {

                StandRB.rotation *= Quaternion.AngleAxis(-0.7f, Vector3.right);
            }
        }
        else
        {
            if (Direction.y > 0)
            {
                StandRB.rotation *= Quaternion.AngleAxis(0.7f, Vector3.forward);
            }
            else
            {
                StandRB.rotation *= Quaternion.AngleAxis(-0.7f, Vector3.forward);
            }
        }
    }
}
