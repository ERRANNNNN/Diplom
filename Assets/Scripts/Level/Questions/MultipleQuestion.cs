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
        throw new System.NotImplementedException();
    }

    public void Initialize(JSONNode Question)
    {
        
    }

    private void GetAccepted()
    {

    }
}
