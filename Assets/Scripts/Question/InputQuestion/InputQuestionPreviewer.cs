using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InputQuestionPreviewer : MonoBehaviour, IQuestionPreviewer
{
    [SerializeField]
    private InputField _InputField;

    [SerializeField]
    private TextMeshProUGUI questionText;

    InputQuestion _Question;

    public InputQuestionChecker _checker;

    public void PreviewQuestion(IQuestion question)
    {
        _Question = (InputQuestion) question;
        questionText.text = _Question.Question;
        InitChecker();
    }

    private void InitChecker()
    {
        _checker.Correct = _Question.Correct;
        _checker._Input = _InputField;
    }

    public IQuestionChecker GetChecker()
    {
        return _checker;
    }
}
