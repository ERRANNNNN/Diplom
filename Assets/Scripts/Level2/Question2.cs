using TMPro;
using UnityEngine;
using System.Collections;

public class Question2 : MonoBehaviour
{
    public IQuestion question;
    public Level2 _Level2;
    [SerializeField] protected TextMeshProUGUI _Comment;
    [SerializeField] protected TextMeshProUGUI _Question;
    [SerializeField] private Color goodColor;
    [SerializeField] private Color badColor;
    private int waitTime = 10;

    protected bool isTrue = false;

    public virtual void Show()
    {
        Debug.Log(question.Type);
    }

    public virtual bool Check()
    {
        if (isTrue) return true;
        else return false;
    }

    public void ShowComment(bool isGood)
    {
        string com;
        if (isGood)
        {
            _Comment.color = goodColor;
            com = "Верно!";
        }
        else
        {
            com = question.Com;
            _Comment.color = badColor;
        }

        _Comment.gameObject.SetActive(true);
        _Comment.text = com;
    }
}
