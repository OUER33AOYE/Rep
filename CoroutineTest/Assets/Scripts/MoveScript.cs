using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float Power = 50,UpPower = 100;

    bool Right = true;
    void Start()
    {
        
    }
    public void MoveRight()
    {
        GetComponent<Animator>().SetBool("StandParametr", false);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * Power);
        if(Right == false)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Right = true;
        }
    }
    public void Jump()
    {
        GetComponent<Animator>().SetBool("StandParametr", false);
        GetComponent<Animator>().SetBool("JumpParametr", true);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * UpPower);
        
    }
    public void MoveLeft()
    {
        GetComponent<Animator>().SetBool("StandParametr", false);
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Power);
        if(Right == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            Right = false;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            GetComponent<Animator>().SetBool("StandParametr", true);
        }
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Animator>().SetBool("JumpParametr", false);
        }
    }
    void Update()
    {
        //transform.Translate(Direction * Time.deltaTime);
    }
    
}
