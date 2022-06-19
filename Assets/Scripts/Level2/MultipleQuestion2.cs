using UnityEngine;
using UnityEngine.UI;

public class MultipleQuestion2 : Question2
{
    private MultipleQuestion multQuest;
    [SerializeField] private Toggle[] toggles = new Toggle[4];
    [SerializeField] private Text[] togglesLabels = new Text[4];

    public override void Show()
    {
        multQuest = (MultipleQuestion)question;
        _Question.text = multQuest.Question;
        for (int toggleNum = 0; toggleNum < 4; toggleNum++)
        {
            togglesLabels[toggleNum].text = multQuest.values[toggleNum];
        }
    }

    public override bool Check()
    {
        int correctsCounter = 0;
        Debug.Log(multQuest);
        foreach (string correct in multQuest.correct)
        {
            if (toggles[int.Parse(correct) - 1].isOn)
            {
                correctsCounter++;
            }
        }

        if (correctsCounter == multQuest.correct.Count) isTrue = true;
        else isTrue = false;

        return base.Check();
    }
}
