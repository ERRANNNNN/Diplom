using SimpleJSON;
using UnityEngine;

class ChaptersLoader : MonoBehaviour
{
    public TextAsset JsonFile;

    public void Start()
    {
        if(Storage.Chapters.Count == 0)
        {
            JSONNode MainNode = JSON.Parse(JsonFile.text);
            JSONArray chapters = MainNode["chapters"].AsArray;
            foreach (JSONNode chapter in chapters)
            {
                Chapter newChapter = new Chapter(chapter);
                Storage.Chapters.Add(newChapter);
            }
        }
    }
}
