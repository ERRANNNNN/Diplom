using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChapterPreviewer : MonoBehaviour, IPointerClickHandler
{
    private Chapter _Chapter;
    public TextMeshProUGUI _Number;
    public TextMeshProUGUI _Theme;
    public TextMeshProUGUI _Percentage;

    public void Init(Chapter chapter, int number)
    {
        _Chapter = chapter;
        _Number.text = "Глава " + (number+1).ToString();
        _Theme.text = _Chapter.name;
        _Percentage.text = _Chapter.percentOfCompleted.ToString() + "%";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
