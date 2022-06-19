using UnityEngine;
using SimpleJSON;
using System;

[Serializable]
public class OneQuestion : IQuestion
{
    public string Question;
    public string Type => "one";

    public string Com => Comment;

    public string Correct;
    public string[] values = new string[4];
    public string Comment;

    public OneQuestion(JSONNode QuestionNode)
    {
        Question = QuestionNode["question"];
        Correct = QuestionNode["correct"];
        Comment = QuestionNode["comment"];

        JSONArray jsonValues = QuestionNode["values"].AsArray;
        for(int i = 0; i < jsonValues.Count; i++)
        {
            values[i] = jsonValues[i];
        }
    }
}
