using UnityEngine;
using System.Collections.Generic;

public class EndTheTestBtn : MonoBehaviour
{
    public List<IQuestionChecker> checkers;
    public GameObject ResultsObj;
    public TestResultsPanel _ResultsPanel;

    public void EndTest()
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        int corrects = 0;

        foreach(IQuestionChecker checker in checkers)
        {
            if(checker.Check())
            {
                corrects++;
            }
        }

        ResultsObj.SetActive(true);
        _ResultsPanel.Initialize(checkers.Count, corrects);
    }
    
}
