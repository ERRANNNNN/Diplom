using UnityEngine;
using UnityEngine.EventSystems;

public class NextLogicLevelBTN : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        LogicMiniGame.NextLevel();
    }
}
