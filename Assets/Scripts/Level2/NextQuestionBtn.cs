using UnityEngine;
using UnityEngine.EventSystems;

public class NextQuestionBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Question2 _question;
    private bool isComment;
    private bool isCorrect = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        if (!isComment)
        {
            isCorrect = _question.Check();
            _question.ShowComment(isCorrect);
            isComment = true;
        } else {
            _question._Level2.Next(isCorrect);
        }
    }
}
