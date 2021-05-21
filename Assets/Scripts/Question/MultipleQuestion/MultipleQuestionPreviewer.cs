using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultipleQuestionPreviewer : MonoBehaviour, IQuestionPreviewer
{
    [SerializeField]
    private Text[] Labels = new Text[4];

    public Toggle[] Toggles = new Toggle[4];

    [SerializeField]
    private TextMeshProUGUI questionText;

    MultipleQuestion _Question;


    public void PreviewQuestion(IQuestion question)
    {
        _Question = (MultipleQuestion)question;
        questionText.text = _Question.Question;

        for (int i = 0; i < _Question.values.Length; i++)
        {
            Debug.Log(_Question.values[i]);
            Labels[i].text = _Question.values[i];
        }
    }
}