using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartBtn : MonoBehaviour, IPointerClickHandler
{
    public GameObject chaptersObj;
    public GameObject menuObj;

    public void OnPointerClick(PointerEventData eventData)
    { 
        chaptersObj.SetActive(true);
        menuObj.SetActive(false);
    }
}
