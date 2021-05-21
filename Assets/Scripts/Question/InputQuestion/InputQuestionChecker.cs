using UnityEngine.UI;
using UnityEngine;

public class InputQuestionChecker : MonoBehaviour, IQuestionChecker
{
    public InputField _Input;
    public string Correct;

    public bool Check()
    {
        Correct = Correct.ToLower();
        string answer = _Input.text.ToLower();
        if (Correct == answer)
            return true;
        else
            return false;
    }
}
