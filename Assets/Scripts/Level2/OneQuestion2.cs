using UnityEngine;
using UnityEngine.UI;

public class OneQuestion2 : Question2
{
    private OneQuestion oneQuest;
    private ImageQuestion imageQuest;
    [SerializeField] private Toggle[] toggles = new Toggle[4];
    [SerializeField] private Text[] togglesLabels = new Text[4];
    [SerializeField] private Image[] _images;
    public bool isImage = false;

    public override void Show()
    {
        if(isImage)
        {
            imageQuest = (ImageQuestion)question;
            _Question.text = imageQuest.Question;
            for (int toggleNum = 0; toggleNum < 4; toggleNum++)
            {
                togglesLabels[toggleNum].text = imageQuest.values[toggleNum];
            }
            for(int im = 0; im < 4; im++)
            {
                _images[im].sprite = Resources.Load<Sprite>("Level/" + imageQuest.images[im]);
            }
        } else {
            oneQuest = (OneQuestion)question;
            _Question.text = oneQuest.Question;
            for (int toggleNum = 0; toggleNum < 4; toggleNum++)
            {
                togglesLabels[toggleNum].text = oneQuest.values[toggleNum];
            }
        }
    }

    public override bool Check()
    {
        if(isImage)
        {
            if (toggles[int.Parse(imageQuest.Correct) - 1].isOn) isTrue = true;
            else isTrue = false;
            return base.Check();
        } else {
            if (toggles[int.Parse(oneQuest.Correct) - 1].isOn) isTrue = true;
            else isTrue = false;
            return base.Check();
        }
    }
}
