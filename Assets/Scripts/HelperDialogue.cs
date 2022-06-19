using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HelperDialogue : MonoBehaviour, IPointerClickHandler
{
    public string[] dialogues;
    private int current = 0;
    [SerializeField] private TextMeshProUGUI _text;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(current+1 == dialogues.Length)
        {
            gameObject.SetActive(false);
        } else
        {
            current++;
            _text.text = dialogues[current];
        }
        
    }

    public void Init()
    {
        current = 0;
        _text.text = dialogues[current];
    }
}
