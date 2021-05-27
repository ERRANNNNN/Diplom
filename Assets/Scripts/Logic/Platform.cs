using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, IInput
{
    [SerializeField]
    private RectTransform _transform;

    [SerializeField]
    private int id;

    private bool isOpen = false;

    public void Get(IOutput output = null, bool active = false)
    {
        if(active)
        {
            Open();
        } else {
            Close();
        }
        
    }

    private void Open()
    {
        if(!isOpen)
        {
            _transform.anchoredPosition = new Vector2(-160, 0);
            isOpen = !isOpen;
        }
    }

    private void Close()
    {
        if(isOpen)
        {
            _transform.anchoredPosition = new Vector2(0, 0);
            isOpen = !isOpen;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Crystall _crystall = collision.gameObject.GetComponent<Crystall>();
        _crystall.CheckBreak(id);
    }
}
