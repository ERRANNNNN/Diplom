using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Level : IQuestion
{
    public string Name;
    public List<IQuestion> Questions = new List<IQuestion>();
    public bool isCompleted;

    public Level(JSONNode levelNode)
    {
        Name = levelNode["name"];
        JSONArray questionsArray = levelNode["test"].AsArray;
        foreach(JSONNode node in questionsArray)
        {
            string type = node["type"];
            switch(type)
            {
                case "input":
                    IQuestion question = new InputQuestion(node);
                    Questions.Add(question);
                    break;
                case "one":
                    question = new OneQuestion(node);
                    Questions.Add(question);
                    break;
                case "multiple":
                    question = new MultipleQuestion(node);
                    break;
                case "image-input":
                    break;
            }
        }
    }
}
