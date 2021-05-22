﻿using System.Collections.Generic;
using SimpleJSON;

public class Level
{
    public string Name;
    public List<IQuestion> Questions = new List<IQuestion>();
    public bool isCompleted;
    public int stars;

    public Level(JSONNode levelNode)
    {
        Name = levelNode["name"];
        JSONArray questionsArray = levelNode["test"].AsArray;

        InitQuestions(questionsArray);
    }

    private void InitQuestions(JSONArray questionsArray)
    {
        foreach (JSONNode node in questionsArray)
        {
            string type = node["type"];

            IQuestion question;

            switch (type)
            {
                case "input":
                    question = new InputQuestion(node);
                    Questions.Add(question);
                    break;
                case "one":
                    question = new OneQuestion(node);
                    Questions.Add(question);
                    break;
                case "multiple":
                    question = new MultipleQuestion(node);
                    Questions.Add(question);
                    break;
                case "image-input":
                    break;
            }
        }
    }
}
