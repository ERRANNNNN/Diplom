using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPreviewer : MonoBehaviour
{
    public Transform _TLevelPreviewer;
    public Transform _TParentOfLevel;
    private List<GameObject> LevelObjects = new List<GameObject>();

    public void PreviewLevelsOfChapter(Chapter chapter)
    {
        if(LevelObjects.Count != 0)
        {
            foreach(GameObject levelObject in LevelObjects)
            {
                Destroy(levelObject);
            }
        }

        for(int i = 0; i < chapter.Levels.Count; i++)
        {
            GameObject _TObj = Instantiate(_TLevelPreviewer, _TParentOfLevel).gameObject;
            LevelObjects.Add(_TObj);
            LevelPreviewer _LevelPreviewer = _TObj.GetComponent<LevelPreviewer>();
            _LevelPreviewer.Init(chapter.Levels[i], i);
        }
    }
}
