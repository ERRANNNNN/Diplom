using UnityEngine.EventSystems;
using UnityEngine;

public class BackBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject PanelToClose;
    [SerializeField]
    private GameObject PanelToOpen;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
        PanelToClose.SetActive(false);
        PanelToOpen.SetActive(true);
    }
}
