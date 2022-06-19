using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPreviewer : MonoBehaviour
{
    public Transform _TLevelPreviewer;
    public Transform _TParentOfLevel;

    private List<GameObject> LevelObjects = new List<GameObject>();

    public void Start()
    {
        if(LevelObjects.Count == 0)
        {
            PreviewLevelsOfChapter(Storage.CurrentChapter);
        }
    }

    public void PreviewLevelsOfChapter(Chapter chapter)
    {
        if(LevelObjects.Count != 0)
        {
            foreach(GameObject levelObject in LevelObjects)
            {
                Destroy(levelObject);
            }

            LevelObjects = new List<GameObject>();
        }

        for(int levelNumber = 0; levelNumber < chapter.Levels.Count; levelNumber++)
        {
            GameObject _TObj = Instantiate(_TLevelPreviewer, _TParentOfLevel).gameObject;
            LevelObjects.Add(_TObj);
            LevelPreviewer _LevelPreviewer = _TObj.GetComponent<LevelPreviewer>();
            _LevelPreviewer.Init(chapter.Levels[levelNumber], levelNumber);
        }
    }
}
