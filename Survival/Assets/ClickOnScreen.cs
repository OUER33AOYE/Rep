using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2 Tij;
    public static Vector2 GetTij(Vector2 MXY)
    {
        if (MXY.x >= -4.205f && MXY.x <= 4.405f && MXY.y >= -4.405f && MXY.y <= 4.205f)
        {
            MXY = MXY - new Vector2(-4 - 0.205f, 4 + 0.205f);
            return new Vector2((int)(Mathf.Abs(MXY.y) / 0.41f), (int)(MXY.x / 0.41f));
        }
        else
        {
            return new Vector2(-1, -1);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Vector2 MXY = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Tij = GetTij(MXY);
    }
}
