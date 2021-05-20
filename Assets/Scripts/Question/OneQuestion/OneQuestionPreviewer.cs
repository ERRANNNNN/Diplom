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

    public void PreviewQuestion(IQuestion question)
    {
        _OneQuestion = (OneQuestion)question;

        for(int i = 0; i < _OneQuestion.values.Length; i++)
        {
            Labels[i].text = _OneQuestion.values[i];
        }
    }
}
