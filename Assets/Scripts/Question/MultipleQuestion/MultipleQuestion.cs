using System.Collections.Generic;
using SimpleJSON;

public class MultipleQuestion : IQuestion
{
    public string Question;
    public string Type => "multiple";
    public List<string> correct = new List<string>();
    public string[] values = new string[4];

    public MultipleQuestion(JSONNode QuestionNode)
    {
        Question = QuestionNode["question"];
        JSONArray jsonCorrects = QuestionNode["correct"].AsArray;
        JSONArray jsonValues = QuestionNode["values"].AsArray;

        foreach(JSONNode node in jsonCorrects)
        {
            correct.Add(node);
        }
        
        for(int i = 0; i < jsonValues.Count; i++)
        {
            values[i] = jsonValues[i];
        }
    }
}
