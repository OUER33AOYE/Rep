using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupScript : MonoBehaviour
{
   private float disappearTimer;
    private Color textColor;
    public static PopupScript Create(Vector3 xy,int value, GameObject PopupPrefab)
    {
        GameObject instance = Instantiate(PopupPrefab,xy,Quaternion.identity) as GameObject;
        PopupScript ps = instance.GetComponent<PopupScript>();
        ps.SetValue(value);
        return ps;
    }
    public void SetValue(int value)
    {
        GetComponent<TextMeshPro>().text = value.ToString();
        disappearTimer = 3f;
        textColor = GetComponent<TextMeshPro>().color;
    }
    private void Update()
    {
        float SpeedY = 2f,SpeedC = 2f;
        transform.position += new Vector3(0f, SpeedY * Time.deltaTime,0f);
        disappearTimer -= Time.deltaTime;
        textColor.a -= SpeedC*Time.deltaTime;
        GetComponent<TextMeshPro>().color = textColor;
        if (disappearTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
