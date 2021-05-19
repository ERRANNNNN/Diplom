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
        PanelToClose.SetActive(false);
        PanelToOpen.SetActive(true);
    }
}
