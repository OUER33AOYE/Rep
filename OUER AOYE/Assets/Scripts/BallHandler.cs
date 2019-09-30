using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static Vector3 CurrentLevelPosition = new Vector3(1.689702f, -0.5875826f, 7.171316f);
    public GameObject Prefab,Old;
    GameObject Current;
    
    private void Start()
    {
        Current = Old;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LevelCompleteCheck")
        {
            Old = Current;
            CurrentLevelPosition.y -= 25;
            CurrentLevelPosition.z += 6;
            Old.GetComponent<LevelHandler>().Control = false;
            StartCoroutine(DestroyAfter5Seconds(Old));
            Current = Instantiate(Prefab,CurrentLevelPosition,Quaternion.identity) as GameObject;
        }
    }
    IEnumerator DestroyAfter5Seconds(GameObject old)
    {
        yield return new WaitForSeconds(5f);
        Destroy(old);
    }
}
