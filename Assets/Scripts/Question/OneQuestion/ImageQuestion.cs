using UnityEngine;
using SimpleJSON;
using System;

[Serializable]
public class ImageQuestion : IQuestion
{
    public string Question;
    public string Type => "image";

    public string Com => Comment;

    public string Correct;
    public string[] values = new string[4];
    public string Comment;
    public string[] images = new string[4];

    public ImageQuestion(JSONNode QuestionNode)
    {
        Question = QuestionNode["question"];
        Correct = QuestionNode["correct"];
        Comment = QuestionNode["comment"];

        JSONArray jsonImages = QuestionNode["images"].AsArray;
        for (int i = 0; i < jsonImages.Count; i++)
        {
            images[i] = jsonImages[i];
        }

        JSONArray jsonValues = QuestionNode["values"].AsArray;
        for (int i = 0; i < jsonValues.Count; i++)
        {
            values[i] = jsonValues[i];
        }
    }
}
