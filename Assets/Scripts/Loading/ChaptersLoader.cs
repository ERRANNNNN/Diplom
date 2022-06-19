using SimpleJSON;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;

class ChaptersLoader : MonoBehaviour
{
    public TextAsset JsonFile;
    private string _path;

    public void Start()
    {
        _path = Application.persistentDataPath + "chapters.bin";
        if (Storage.Chapters.Count == 0)
        {
            if(SaveExists())
            {
                LoadDevice();
            } else {
                LoadDB();
            }
        }
    }

    private void LoadDevice()
    {
        BinaryFormatter BF = new BinaryFormatter();
        using (FileStream fs = new FileStream(_path, FileMode.Open))
        {
            Storage.Chapters = (List<Chapter>)BF.Deserialize(fs);
            Debug.Log("Главы загружены с устройства!");
        }
    }

    private void LoadDB()
    {
        JSONNode MainNode = JSON.Parse(JsonFile.text);
        JSONArray chapters = MainNode["chapters"].AsArray;

        foreach (JSONNode chapter in chapters)
        {
            Chapter newChapter = new Chapter(chapter);
            Storage.Chapters.Add(newChapter);
        }
        Debug.Log("Главы загружены из json!");
        Storage.SaveChapters();
    }

    private bool SaveExists()
    {
        if(File.Exists(_path))
        {
            return true;
        } else {
            return false;
        }
    }
}
