using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public Vector2 a, b, c, d;
    // Start is called before the first frame update
    void Start()
    {
        List<int> path = new List<int>();
        CreateGround.FindPath(new Vector2(10,10),new Vector2(13,11),path);
        Debug.Log(path.Count);
        foreach(int v in path)
        {
            CreateGround.Map[v/21][v%21].GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        a = ClickOnScreen.GetTij(new Vector2(transform.position.x - 0.2f, transform.position.y + 0.2f));
        b = ClickOnScreen.GetTij(new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f));
        c = ClickOnScreen.GetTij(new Vector2(transform.position.x - 0.2f, transform.position.y - 0.2f));
        d = ClickOnScreen.GetTij(new Vector2(transform.position.x + 0.2f, transform.position.y - 0.2f));
    }
}
