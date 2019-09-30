using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour
{
    public GameObject TilePrefab,TileMap,Player;
    
    public static GameObject[][] Map = new GameObject [21][];
    public static int[] p = new int[441], q = new int[441], qq = new int[441];
    // Start is called before the first frame update
    private void Awake()
    {
        float StartX = -4, StartY = 4;
        for(int i=0;i<21;i++)
        {
            Map[i] = new GameObject[21];
            for(int j=0;j<21;j++)
            {
                Map[i][j] = Instantiate(TilePrefab,new Vector2(StartX + j*0.41f,StartY - i*0.41f),Quaternion.identity);
                Map[i][j].gameObject.name = "Tile[" + i.ToString() + "]" + "[" + j.ToString() + "]";
                Map[i][j].transform.SetParent(TileMap.transform,true);
            }
        }
    }
    void Start()
    {
        
    }
    public static void FindPath(Vector2 st,Vector2 fn,List<int> ans)
    {
        int qt=0, qqt=0;
        for(int i=0;i<441;i++)
        {
            p[i] = -1;
        }
        q[qt++] = (int)(st.x)*21 + (int)st.y;
        int target = (int)fn.x * 21 + (int)fn.y;
        while (qt>0)
        {
            Debug.Log(string.Format("{0} bfs!",qt));
            for(int i=0;i<qt;i++)
            {
                int v = q[i];
                Map[v / 21][v % 21].GetComponent<SpriteRenderer>().color = Color.black;
                if (v==target)
                {
                    Debug.Log("Found!");
                    while (p[v]!=-1)
                    {
                        ans.Add(p[v]);
                        v = p[v];
                    }
                    return; 
                }
                if(v/21>0)
                {
                    if (p[v - 21] == -1)
                    {
                        p[v - 21] = v;
                        qq[qqt++]=(v - 21);
                    }
                }
                if((v+1)%21 != 0)
                {
                    if (p[v + 1] == -1)
                    {
                        p[v + 1] = v;
                        qq[qqt++] = (v + 1);
                    }
                }
                if(v%21 !=0)
                {
                    if (p[v - 1] == -1)
                    {
                        p[v - 1] = v;
                        qq[qqt++] = (v - 1);
                    }
                }
                if(v/21!=20)
                {
                    if (p[v + 21] == -1)
                    {
                        p[v + 21] = v;
                        qq[qqt++] = (v + 21);
                    }
                }
            }
            qt = qqt;
            for(int i=0;i<qqt;i++)
            {
                q[i] = qq[i];
            }
            qqt = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
