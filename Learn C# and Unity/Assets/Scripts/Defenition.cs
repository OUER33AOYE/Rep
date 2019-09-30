using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class Defenition : MonoBehaviour
{
    public int DefenitionIndex;
    public void Select(){
        DefenitionMeaning.Selected = DefenitionIndex;
    }
    public void Delete()
    {
        PlayerPrefs.DeleteKey(DefenitionMeaning.sv.s[DefenitionIndex]);
        for (int i = DefenitionIndex; i < DefenitionMeaning.sv.count - 1; i++)
        {
            DefenitionMeaning.DefenitionList[i] = DefenitionMeaning.DefenitionList[i + 1];            
            DefenitionMeaning.sv.s[i] = DefenitionMeaning.sv.s[i + 1];
            DefenitionMeaning.DefenitionList[i].GetComponent<Defenition>().DefenitionIndex--;
            
        }
        if(DefenitionIndex < DefenitionMeaning.Selected)
        {
            DefenitionMeaning.Selected--;
        }
        DefenitionMeaning.sv.count--;
        Destroy(gameObject);
    }
}
