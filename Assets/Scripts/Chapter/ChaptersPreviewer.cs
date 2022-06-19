using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaptersPreviewer : MonoBehaviour
{
    public Transform _TChapterPreviewer;
    public Transform _TParentOfChapter;
    public GameObject LevelsPreviewerObject;
    public LevelsPreviewer _LevelsPreviewer;
    [SerializeField] private GameObject _TheoryPreviewer;
    [SerializeField] private TheoryPreviewer _TheoryPreviewerComponent;

    void Start()
    {
        for (int numberOfChapter = 0; numberOfChapter < Storage.Chapters.Count; numberOfChapter++)
        {
            Chapter chapter = Storage.Chapters[numberOfChapter];
            Transform _TObj = Instantiate(_TChapterPreviewer, _TParentOfChapter);
            ChapterPreviewer _ChapterPreviewer = _TObj.gameObject.GetComponent<ChapterPreviewer>();
            _ChapterPreviewer._TheoryPreviewer = _TheoryPreviewer;
            _ChapterPreviewer._TheoryPreviewerComponent = _TheoryPreviewerComponent;
            _ChapterPreviewer.Init(chapter, numberOfChapter, this);
        }
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenLevels(Chapter chapter)
    {
        Storage.CurrentChapter = chapter;
        LevelsPreviewerObject.SetActive(true);
        _LevelsPreviewer.PreviewLevelsOfChapter(chapter);
        Close();
    }
}
