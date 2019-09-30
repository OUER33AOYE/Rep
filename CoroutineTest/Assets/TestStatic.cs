using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStatic : MonoBehaviour
{
    public static int count;
    public int n;
    static TestStatic()
    {
        count = 0;
        Debug.Log("static constructor TS");
    }
    public TestStatic()
    {
        count++;
        n = count;
        Debug.Log("another instance of TS");
    }
    private void Start()
    {
        Debug.Log(n);
    }
}
