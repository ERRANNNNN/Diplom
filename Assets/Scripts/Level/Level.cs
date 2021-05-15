using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

[Serializable]
public class Level
{
    public string Name { private set; get; }
    public IQuestion[] Test;
    private JSONNode LevelNode;
    
    public Level (JSONNode level)
    {
        LevelNode = level;
        Name = LevelNode["level"];
    }

    private void InitializeQuestions()
    {
        JSONArray questions = LevelNode["test"].AsArray;
        foreach(JSONNode question in questions)
        {
            if(question["type"] == "multiple")
            {
                IQuestion quest = new MultipleQuestion();
                quest.Initialize(question);
            }
        }
    }
}
