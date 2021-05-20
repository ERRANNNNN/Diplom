using UnityEngine;
using SimpleJSON;

class InputQuestion : IQuestion
{
    public string Question;
    public string Type => "input";
    public string Correct;

    public InputQuestion(JSONNode QuestionNode)
    {
        Question = QuestionNode["question"];
        Correct = QuestionNode["correct"];
    }
}
