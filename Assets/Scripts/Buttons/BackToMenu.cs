using UnityEngine;
using UnityEngine.EventSystems;

public class BackToMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string PlaneName = "Menu";

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        MainMenu.PlaneName = PlaneName;
        Loading.LoadScene("MainMenu");
    }
}
