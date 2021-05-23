using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

[System.Serializable]
public class Turner : MonoBehaviour, IPointerClickHandler, IOutput
{
    [SerializeField]
    private bool IsActive = false;
    
    [SerializeField]
    private GameObject[] paths;

    private List<IInput> Inputs;

    [SerializeField]
    private Image _Image;
    [SerializeField]
    private Color ActiveColor;
    [SerializeField]
    private Color UnactiveColor;

    private void Start()
    {
        GetInputs();
        StartCoroutine("Init");
        ChangeView(IsActive);
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(0.2f);
        
        foreach (IInput input in Inputs)
        {
            Send(input, IsActive);
        }
    }

    private void GetInputs()
    {
        Inputs = paths.Select(x => x.GetComponent<IInput>()).ToList();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IsActive = !IsActive;

        ChangeView(IsActive);

        foreach(IInput input in Inputs)
        {
            Send(input, IsActive);
        }
    }

    public void Send(IInput input, bool active)
    {
        input.Get(default, active);
    }

    private void ChangeView(bool active)
    {
        if (active)
            _Image.color = ActiveColor;
        else
            _Image.color = UnactiveColor;
    }
}
