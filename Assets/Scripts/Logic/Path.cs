using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour, IOutput, IInput
{
    public bool IsActive { get; private set; }

    [SerializeField]
    private IInput input;
    [SerializeField]
    private Color ActiveColor;
    [SerializeField]
    private Color UnactiveColor;
    [SerializeField]
    private Image _Image;

    public void Send(IInput input, bool active)
    {
        input.Get(this, active);
    }

    public void Get(IOutput output, bool active)
    {
        IsActive = !IsActive;
        ChangeView(IsActive);
        //Send(input, IsActive);
    }

    private void ChangeView(bool active)
    {
        if (active)
            _Image.color = ActiveColor;
        else
            _Image.color = UnactiveColor;
    }
}
