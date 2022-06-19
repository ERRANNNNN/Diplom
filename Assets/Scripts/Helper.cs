using UnityEngine;
using UnityEngine.EventSystems;

public class Helper : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private HelperDialogue HelperPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        HelperPanel.gameObject.SetActive(true);
        HelperPanel.Init();
    }
}
