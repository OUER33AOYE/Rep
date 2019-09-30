using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class DefenitionMeaning : MonoBehaviour
{
    public static Save sv;
    public static int Selected = -1,ML = 0;
    public static GameObject[] DefenitionList = new GameObject[5000], MeaningList = new GameObject [100];
    private string path;
    public GameObject DefenitionPrefab, MeaningPerfab;
    public Transform DefenitionContent, MeaningContent;
    public InputField Defenition, Meaning;
    public Button AddButton, SaveButton;
    
    int OldSelected = -1;
    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath,"Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save9.json");
#endif
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
        }
        else
        {
            sv = new Save();
        }
        for (int i = 0; i < sv.count; i++)
        {
            InstanceDefenition(i, sv.s[i]);
        }
    }
    private void Update()
    {
        if(Defenition.text == "")
        {
            SaveButton.interactable = false;
        }
        else
        {
            SaveButton.interactable = true;
        }
        if(Meaning.text == "")
        {
            AddButton.interactable = false;
        }
        else if(SaveButton.interactable == true)
        {
            AddButton.interactable = true;
        }
        if(Selected!=OldSelected)
        {
            if (Selected != -1)
            {
                if(OldSelected!=-1) {

                    DefenitionList[OldSelected].transform.Find("DefenitionPrefabDelete").GetComponent<Button>().interactable = true;
                }
                Select();
            }
            OldSelected = Selected;            
        }
    }
    public void Add()
    {
        InstanceMeaning(ML,Meaning.text);
        Meaning.text = "";
    }
    public void Save()
    {
        string temp = "";
        for (int i = 0; i < ML; i++)
        {
            temp += MeaningList[i].transform.Find("MeaningPrefabText").GetComponent<Text>().text + '$';
        }

        if (Selected == -1)
        {
            sv.s[sv.count] = Defenition.text;
            PlayerPrefs.SetString(sv.s[sv.count], temp);
            InstanceDefenition(sv.count, sv.s[sv.count]);
            sv.count++;
        }
        else
        {
            DefenitionList[Selected].transform.Find("DefenitionPrefabDelete").GetComponent<Button>().interactable = true;
            PlayerPrefs.DeleteKey(sv.s[Selected]);
            PlayerPrefs.SetString(sv.s[Selected], temp);
        }

        ClearMeaningList();
        
        Selected = -1;
        Defenition.text = "";
        Defenition.interactable = true;
        Meaning.text = "";
    }
    public void Select()
    {
        Defenition.text = sv.s[Selected];
        Defenition.interactable = false;
        ClearMeaningList();
        string s = PlayerPrefs.GetString(sv.s[Selected]);
        string temp = "";
        for(int i=0;i<s.Length;i++)
        {
            if(s[i]=='$')
            {
                InstanceMeaning(ML,temp);
                temp = "";
            }
            else
            {
                temp += s[i];
            }
        }
        DefenitionList[Selected].transform.Find("DefenitionPrefabDelete").GetComponent<Button>().interactable = false;
    }
    void InstanceMeaning(int i,string s)
    {
        GameObject instance = Instantiate(MeaningPerfab) as GameObject;
        instance.transform.SetParent(MeaningContent, false);
        instance.GetComponent<Meaning>().MeaningIndex = i;
        instance.transform.Find("MeaningPrefabText").GetComponent<Text>().text = s;
        MeaningList[i] = instance;
        ML++;
    }
    void ClearMeaningList()
    {
        for (int i = 0; i < ML; i++)
        {
            Destroy(MeaningList[i]);
        }
        ML = 0;
    }
    void InstanceDefenition(int i,string s)
    {
        GameObject instance = Instantiate(DefenitionPrefab) as GameObject;
        instance.transform.SetParent(DefenitionContent,false);
        instance.GetComponent<Defenition>().DefenitionIndex = i;
        instance.transform.Find("DefenitionPrefabSelect").GetComponent<Button>().transform.Find("Text").GetComponent<Text>().text = s;
        DefenitionList[i] = instance;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause) {
        if(pause) File.WriteAllText(path,JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
}
[SerializeField]
public class Save
{
    public int count;
    public string[] s;
    public Save() {
        s = new string [5000];
    }
}
