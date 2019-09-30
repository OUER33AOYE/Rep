using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meaning : MonoBehaviour
{
    public int MeaningIndex;
    public void Delete()
    {
        for (int i = MeaningIndex; i < DefenitionMeaning.ML - 1; i++)
        {
            DefenitionMeaning.MeaningList[i] = DefenitionMeaning.MeaningList[i + 1];
            DefenitionMeaning.MeaningList[i].GetComponent<Meaning>().MeaningIndex--;
        }
        DefenitionMeaning.ML--;
        Destroy(gameObject);
    }
}
