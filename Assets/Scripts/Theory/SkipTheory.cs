using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkipTheory : MonoBehaviour, IPointerClickHandler
{
    public Chapter _chapter;
    [SerializeField] private GameObject Theory;
    [SerializeField] private ChaptersPreviewer _chaptersPreviewer;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
        _chaptersPreviewer.OpenLevels(_chapter);
        Theory.SetActive(false);
    }
}
