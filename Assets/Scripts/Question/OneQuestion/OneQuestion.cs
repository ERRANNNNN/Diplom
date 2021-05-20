using UnityEngine;
using SimpleJSON;

public class OneQuestion : IQuestion
{
    public string Question;
    public string Type => "one";
    public string Correct;
    public string[] values = new string[4];

    public OneQuestion(JSONNode QuestionNode)
    {
        Question = QuestionNode["question"];
        Correct = QuestionNode["correct"];

        JSONArray jsonValues = QuestionNode["values"].AsArray;
        for(int i = 0; i < jsonValues.Count; i++)
        {
            values[i] = jsonValues[i];
        }
    }
}
