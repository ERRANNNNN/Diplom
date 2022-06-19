using UnityEngine;
using SimpleJSON;
using System;

[Serializable]
class InputQuestion : IQuestion
{
    public string Question;
    public string Type => "input";

    public string Com => Comment;

    public string Correct;
    public string Comment;

    public InputQuestion(JSONNode QuestionNode)
    {
        Question = QuestionNode["question"];
        Correct = QuestionNode["correct"];
        Comment = QuestionNode["comment"];
    }
}
