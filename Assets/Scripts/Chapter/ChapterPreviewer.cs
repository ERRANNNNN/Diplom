using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChapterPreviewer : MonoBehaviour, IPointerClickHandler
{
    private Chapter _Chapter;
    [SerializeField]
    private TextMeshProUGUI _Number;
    [SerializeField]
    private TextMeshProUGUI _Theme;
    [SerializeField]
    private TextMeshProUGUI _Percentage;

    [SerializeField]
    private ChaptersPreviewer _ChaptersPreviewer;

    public void Init(Chapter chapter, int number, ChaptersPreviewer _ChaptersPreviewer)
    {
        this._ChaptersPreviewer = _ChaptersPreviewer;
        _Chapter = chapter;
        _Number.text = "Глава " + (number+1).ToString();
        _Theme.text = _Chapter.name;
        _Percentage.text = _Chapter.percentOfCompleted.ToString() + "%";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _ChaptersPreviewer.OpenLevels(_Chapter);
    }
}
