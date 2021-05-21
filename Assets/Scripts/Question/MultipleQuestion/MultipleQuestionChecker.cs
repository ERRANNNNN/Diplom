using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class MultipleQuestionChecker : MonoBehaviour, IQuestionChecker
{
    public Toggle[] Toggles = new Toggle[4];
    public List<string> corrects = new List<string>();

    public bool Check()
    {
        int correctsCounter = 0;
        
        foreach(string correct in corrects)
        {
            if(Toggles[int.Parse(correct)-1].isOn)
            {
                
                correctsCounter++;
            }
        }

        if (correctsCounter == corrects.Count)
            return true;
        else return false;
    }
}
