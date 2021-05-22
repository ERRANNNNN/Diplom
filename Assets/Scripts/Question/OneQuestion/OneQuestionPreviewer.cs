using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class OneQuestionPreviewer : MonoBehaviour, IQuestionPreviewer
{
    [SerializeField]
    private Text[] Labels = new Text[4];
    
    public Toggle[] Toggles = new Toggle[4];

    [SerializeField]
    private TextMeshProUGUI Question;

    OneQuestion _OneQuestion;

    public OneQuestionChecker _Checker;

    public void PreviewQuestion(IQuestion question)
    {
        _OneQuestion = (OneQuestion)question;
        Question.text = _OneQuestion.Question;

        for(int i = 0; i < _OneQuestion.values.Length; i++)
        {
            Labels[i].text = _OneQuestion.values[i];
        }

        InitChecker();
    }

    private void InitChecker()
    {
        _Checker.Toggles = Toggles;
        _Checker.Correct = int.Parse(_OneQuestion.Correct);
    }

    public IQuestionChecker GetChecker()
    {
        return _Checker;
    }
}
