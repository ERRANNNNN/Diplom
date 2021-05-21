using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OneQuestionChecker : MonoBehaviour, IQuestionChecker
{
    public Toggle[] Toggles = new Toggle[4];
    public int Correct;

    public bool Check()
    {
        if (Toggles[Correct-1].isOn)
            return true;
        else
            return false;
    }
}
