using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

[Serializable]
public class Chapter
{
    public string Name { private set; get; }
    public List<Level> _Levels { private set; get; } = new List<Level>();

    public Chapter(JSONNode chapter)
    {
        JSONArray levels = chapter["levels"].AsArray;
        foreach(JSONNode level in levels)
        {
            Level lvl = new Level(level);
            _Levels.Add(lvl);
            lvl.PrintName();
        }
    }
}
