using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerAttackScript : MonoBehaviour
{
    [SerializeField]private GameObject PrefabArrow;
    [SerializeField] private Transform BirdTarget;
    public static int CountDamage = 0;
    public static void WasAHit(int Damage)
    {
        CountDamage += Damage;
    }
    float Angle(Vector2 a)
    {
        a.Normalize();
        return (a.y < 0 ? 2f * Mathf.PI - Mathf.Acos(a.x) : Mathf.Acos(a.x)) * 180f / Mathf.PI;
    }

    public int t = 0;
    public Text DamageScore;
    public void Shoot()
    {
        var instance = Instantiate(PrefabArrow) as GameObject;
        instance.transform.position = new Vector2(transform.position.x,transform.position.y);
        instance.GetComponent<ArrowScript>().Direction = new Vector2(BirdTarget.position.x - transform.position.x, BirdTarget.position.y - transform.position.y);
        instance.transform.rotation = Quaternion.AngleAxis(Angle(instance.GetComponent<ArrowScript>().Direction) - 180f, Vector3.forward);
    }
    private void Update()
    {
        t++;
        if (t % 55 == 0)
        {
            Shoot();
        }
        DamageScore.text = CountDamage.ToString();
    }
    
}
