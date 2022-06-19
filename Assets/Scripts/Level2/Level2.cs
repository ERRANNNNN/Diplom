using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = System.Random;
using System.Linq;

public class Level2 : MonoBehaviour
{
    [SerializeField] private Transform InputQuestionTransform;
    [SerializeField] private Transform OneQuestionTransform;
    [SerializeField] private Transform MultipleQuestionTransform;
    [SerializeField] private Transform ImageQuestionTransform;
    [SerializeField] private Transform _Content;
    [SerializeField] private TestResultsPanel _TestResultsPanel;

    private List<IQuestion> QuestionsToPresentList;
    private IQuestion CurrentQuestion;
    private GameObject CurrentQuestionObj;

    private int AllQuestionsCount;

    [SerializeField] private TextMeshProUGUI _CountCompleted;

    private int corrects;

    private Random rnd;

    private void Start()
    {
        IQuestion[] quests = new IQuestion[Storage.CurrentLevel.Questions.Count];
        Storage.CurrentLevel.Questions.CopyTo(quests);
        QuestionsToPresentList = quests.ToList();
        AllQuestionsCount = QuestionsToPresentList.Count;
        _CountCompleted.text = "1 из " + AllQuestionsCount.ToString();
        rnd = new Random();
        SetCurrent();
        Preview();
    }

    private void Preview()
    {
        Question2 questionComponent = null;

        switch(CurrentQuestion.Type)
        {
            case "input":
                CurrentQuestionObj = Instantiate(InputQuestionTransform, _Content).gameObject;
                questionComponent = CurrentQuestionObj.GetComponent<InputQuestion2>();
                break;
            case "one":
                CurrentQuestionObj = Instantiate(OneQuestionTransform, _Content).gameObject;
                questionComponent = CurrentQuestionObj.GetComponent<OneQuestion2>();
                break;
            case "multiple":
                CurrentQuestionObj = Instantiate(MultipleQuestionTransform, _Content).gameObject;
                questionComponent = CurrentQuestionObj.GetComponent<MultipleQuestion2>();
                break;
            case "image":
                CurrentQuestionObj = Instantiate(ImageQuestionTransform, _Content).gameObject;
                OneQuestion2 qu = CurrentQuestionObj.GetComponent<OneQuestion2>();
                qu.isImage = true;
                questionComponent = qu;
                break;
        }
        if(questionComponent != null)
        {
            questionComponent._Level2 = this;
            questionComponent.question = CurrentQuestion;
            questionComponent.Show();
        } else {
            throw new MissingComponentException();
        }
        
    }

    public void Next(bool isCorrect)
    {
        corrects = isCorrect ? corrects + 1 : corrects;
        Debug.Log(corrects);

        Destroy(CurrentQuestionObj);

        if (QuestionsToPresentList.Count != 1)
        {
            
            QuestionsToPresentList.Remove(CurrentQuestion);
            _CountCompleted.text = ((AllQuestionsCount - QuestionsToPresentList.Count) + 1).ToString() + " из " + AllQuestionsCount.ToString();
            SetCurrent();
            Preview();
        } else {
            _TestResultsPanel.gameObject.SetActive(true);
            _TestResultsPanel.Initialize(AllQuestionsCount, corrects);
        }
    }

    private void SetCurrent()
    {
        int cur = rnd.Next(QuestionsToPresentList.Count);
        CurrentQuestion = QuestionsToPresentList[cur];
    }
}
