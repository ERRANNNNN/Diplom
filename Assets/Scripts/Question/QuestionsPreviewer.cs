using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsPreviewer : MonoBehaviour
{
    [SerializeField]
    private Transform QuestionsParent;
    [SerializeField]
    private Transform InputQuestion;
    [SerializeField]
    private Transform MultipleQuestion;
    [SerializeField]
    private Transform OneQuestion;
    

    void Start()
    {
        foreach(IQuestion question in Storage.CurrentLevel.Questions)
        {
            IQuestionPreviewer previewer;
            switch(question.Type)
            {
                case "input":
                    Transform questObj = Instantiate(InputQuestion, QuestionsParent);
                    previewer = questObj.gameObject.GetComponent<IQuestionPreviewer>();
                    previewer.PreviewQuestion(question);
                    break;
                case "multiple":
                    Instantiate(MultipleQuestion, QuestionsParent);
                    break;
                case "one":
                    Instantiate(OneQuestion, QuestionsParent);
                    break;
            }
        }
    }
}
