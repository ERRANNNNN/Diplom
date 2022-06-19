using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToLogic : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        Storage.logicHearts = 3;
        Loading.LoadScene("Logic");
    }
}
