using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Vector2 Direction;
    public GameObject PopupPrefab,BloodAnimation;
    float Speed = 5.1f;
    private void Update()
    {
        
        transform.position = new Vector2(transform.position.x +  Direction.normalized.x * Speed * Time.deltaTime, transform.position.y + Direction.normalized.y * Speed * Time.deltaTime);
        if(transform.position.x>25)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var instance = Instantiate(BloodAnimation, transform.position, Quaternion.identity) as GameObject;
            int R = Random.Range(10, 100) * Random.Range(3, 10);
            TowerAttackScript.WasAHit(R);
            PopupScript.Create(transform.position, R , PopupPrefab);
        }
    }
}
