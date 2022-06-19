using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Linq;
using System;

[Serializable]
public class Chapter
{
    public List<Level> Levels = new List<Level>();
    public List<Level> CompletedLevels { get => (Levels.Where(level => level.isCompleted).ToList()); }
    public string name;
    public float percentOfCompleted { get => (Levels.Count != 0) ? (CompletedLevels.Count / (Levels.Count / 100f)) : 0; }

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
