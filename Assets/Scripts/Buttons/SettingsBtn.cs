using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject Sets;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        Sets.SetActive(true);
    }
}
