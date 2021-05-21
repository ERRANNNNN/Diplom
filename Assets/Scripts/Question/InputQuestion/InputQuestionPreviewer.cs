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

    public void PreviewQuestion(IQuestion question)
    {
        _Question = (InputQuestion) question;
        questionText.text = _Question.Question;
    }
}
