using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Loading : MonoBehaviour
{
    public TextAsset JsonFile;

    private void Start()
    {
        JSONNode chapter = JSON.Parse(JsonFile.text);
        Chapter _Chapter = new Chapter(chapter);
    }
}
