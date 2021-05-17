using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Chapter
{
    public List<Level> Levels = new List<Level>();
    public string name;
    public int percentOfCompleted;

    public Chapter(JSONNode chapterNode)
    {
        name = chapterNode["name"];
        JSONArray _levelsNodeArray = chapterNode["levels"].AsArray;
        foreach(JSONNode _levelNode in _levelsNodeArray)
        {
            Level level = new Level(_levelNode);
            Levels.Add(level);
        }
    }
}
