using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

[System.Serializable]
public class Turner : MonoBehaviour, IPointerClickHandler, IOutput
{
    
    public bool IsActive = false;
    
    [SerializeField]
    private GameObject[] paths;

    private List<IInput> Inputs;

    [SerializeField]
    private Image _Image;

    [SerializeField] private Sprite ActiveSprite;
    [SerializeField] private Sprite NonActiveSprite;

    private void Start()
    {
        GetInputs();
        StartCoroutine("Init");
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(0.2f);
        
        foreach (IInput input in Inputs)
        {
            Send(input, IsActive);
        }
    }

    public void GetInputs()
    {
        Inputs = paths.Select(x => x.GetComponent<IInput>()).ToList();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Suction Cup");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
        ChangeActive(!IsActive);
    }

    public void Send(IInput input, bool active)
    {
        input.Get(default, active);
    }

    private void ChangeView(bool active)
    {
        if (active)
            _Image.sprite = ActiveSprite;
        else
            _Image.sprite = NonActiveSprite;
    }

    public void ChangeActive(bool active)
    {
        IsActive = active;
        foreach (IInput input in Inputs)
        {
            Send(input, active);
        }
        ChangeView(active);
    }
}
