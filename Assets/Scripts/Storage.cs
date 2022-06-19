using SimpleJSON;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Storage
{
    public static List<Chapter> Chapters = new List<Chapter>();
    public static Level CurrentLevel = null;
    public static Chapter CurrentChapter;
    public static JSONArray ChaptersTheoryArray = null;
    public static bool isLogic = false;
    public static int logicHearts = 3;
    public static float Volume = 1;

    public static void SaveGame()
    {
        SaveChapters();
    }

    public static void SaveChapters()
    {
        string path = Application.persistentDataPath + "chapters.bin";
        BinaryFormatter BF = new BinaryFormatter();
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            BF.Serialize(fs, Chapters);
            Debug.Log("Главы сохранены!");
        }
    }
}
