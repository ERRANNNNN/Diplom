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
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        chaptersObj.SetActive(true);
        menuObj.SetActive(false);
    }
}
