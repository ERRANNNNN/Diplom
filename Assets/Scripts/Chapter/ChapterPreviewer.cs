using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChapterPreviewer : MonoBehaviour, IPointerClickHandler
{
    private Chapter _Chapter;
    public GameObject _TheoryPreviewer;
    public TheoryPreviewer _TheoryPreviewerComponent;

    [SerializeField] private TextMeshProUGUI _Number;
    [SerializeField] private TextMeshProUGUI _Theme;
    [SerializeField] private TextMeshProUGUI _Percentage;
    private int ChapterId;

    private ChaptersPreviewer _ChaptersPreviewer;

    public void Init(Chapter chapter, int number, ChaptersPreviewer _ChaptersPreviewer)
    {
        this._ChaptersPreviewer = _ChaptersPreviewer;
        ChapterId = number;
        _Chapter = chapter;
        _Number.text = "Глава " + (number+1).ToString();
        _Theme.text = _Chapter.name;
        _Percentage.text = ((int)_Chapter.percentOfCompleted).ToString() + "%";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap 1");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
        _TheoryPreviewer.SetActive(true);
        Debug.Log(ChapterId);
        Debug.Log(Storage.ChaptersTheoryArray.Count);
        _TheoryPreviewerComponent.Init(ChapterId, _Chapter);
        //_ChaptersPreviewer.OpenLevels(_Chapter);
    }
}
