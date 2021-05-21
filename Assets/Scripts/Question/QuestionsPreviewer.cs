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
            Transform questObj;
            switch(question.Type)
            {
                case "input":
                    questObj = Instantiate(InputQuestion, QuestionsParent);
                    break;
                case "multiple":
                    questObj = Instantiate(MultipleQuestion, QuestionsParent);
                    break;
                case "one":
                    questObj = Instantiate(OneQuestion, QuestionsParent);
                    break;
                default:
                    questObj = null;
                    break;
            }

            if(questObj != null)
            {
                previewer = questObj.gameObject.GetComponent<IQuestionPreviewer>();
                previewer.PreviewQuestion(question);
            }
        }
    }
}
