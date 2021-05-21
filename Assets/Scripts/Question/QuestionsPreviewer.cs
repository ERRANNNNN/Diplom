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
    [SerializeField]
    private Transform EndTheTestBtn;

    public GameObject ResultsPanelObj;

    void Start()
    {
        List<IQuestionChecker> Checkers = new List<IQuestionChecker>();

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
                Checkers.Add(previewer.GetChecker());
                previewer.PreviewQuestion(question);
            }
        }

        GameObject EndTestBtnObj = Instantiate(EndTheTestBtn, QuestionsParent).gameObject;
        EndTheTestBtn _EndTheTestBtn = EndTestBtnObj.GetComponent<EndTheTestBtn>();
        _EndTheTestBtn.checkers = Checkers;
        _EndTheTestBtn.ResultsObj = ResultsPanelObj;
        _EndTheTestBtn._ResultsPanel = ResultsPanelObj.GetComponent<TestResultsPanel>();
    }
}
