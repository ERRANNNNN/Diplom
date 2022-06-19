using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour, IOutput, IInput
{
    public bool IsActive { get; private set; }

    [SerializeField]
    private IInput output;

    [SerializeField]
    private GameObject outputObject;

    [SerializeField]
    private Color ActiveColor;
    [SerializeField]
    private Color UnactiveColor;

    [SerializeField] private Sprite ActiveSprite;
    [SerializeField] private Sprite NonActiveSprite;

    [SerializeField]
    private Image _Image;

    private void Start()
    {
        output = outputObject.GetComponent<IInput>();
    }

    public void Send(IInput input, bool active)
    {
        IOutput thisOutput = this;
        output.Get(thisOutput, active);
    }

    public void Get(IOutput output, bool active)
    {
        IsActive = active;
        ChangeView(IsActive);

        Send(null, IsActive);
    }

    private void ChangeView(bool active)
    {
        if (active)
            _Image.sprite = ActiveSprite;
        else
            _Image.sprite = NonActiveSprite;
    }
}
