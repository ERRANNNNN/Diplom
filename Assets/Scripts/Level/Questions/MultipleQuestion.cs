using SimpleJSON;
using UnityEngine;

class MultipleQuestion : MonoBehaviour, IQuestion
{
    private string[] Values;

    private string Question;

    private string[] CorrectValues;

    private string[] AcceptedValues;

    public bool CheckCorrect()
    {
        return true;
    }

    public void Initialize(JSONNode Question)
    {
        
    }

    private void GetAccepted()
    {

    }
}
