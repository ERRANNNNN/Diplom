using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class TheoryLoader : MonoBehaviour
{
    [SerializeField] private TextAsset JsonFile;

    private void Start()
    {
        if(Storage.ChaptersTheoryArray == null)
        {
            JSONNode node = JSON.Parse(JsonFile.text);
            JSONArray chapters = node["chapters"].AsArray;
            Storage.ChaptersTheoryArray = chapters;
        } 
    }
}
