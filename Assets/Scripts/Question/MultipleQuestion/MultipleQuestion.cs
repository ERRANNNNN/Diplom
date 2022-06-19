using System.Collections.Generic;
using SimpleJSON;
using System;

[Serializable]
public class MultipleQuestion : IQuestion
{
    public string Question;
    public string Type => "multiple";

    public string Com => Comment;

    public List<string> correct = new List<string>();
    public string[] values = new string[4];
    public string Comment;

    public MultipleQuestion(JSONNode QuestionNode)
    {
        Question = QuestionNode["question"];
        JSONArray jsonCorrects = QuestionNode["correct"].AsArray;
        JSONArray jsonValues = QuestionNode["values"].AsArray;
        Comment = QuestionNode["comment"];

        foreach (JSONNode node in jsonCorrects)
        {
            correct.Add(node);
        }
        
        for(int i = 0; i < jsonValues.Count; i++)
        {
            values[i] = jsonValues[i];
        }
    }
}
