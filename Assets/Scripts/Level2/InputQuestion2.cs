using UnityEngine;
using UnityEngine.UI;

public class InputQuestion2 : Question2
{
    private InputQuestion inpQuest;
    [SerializeField] private InputField _inputField;

    public override void Show()
    {
        inpQuest = (InputQuestion) question;
        _Question.text = inpQuest.Question;
    }

    public override bool Check()
    {
        if (_inputField.text.ToLower().Trim() == inpQuest.Correct.ToLower().Trim()) isTrue = true;
        else isTrue = false;

        return base.Check();
    }
}
