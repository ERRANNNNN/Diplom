using UnityEngine.EventSystems;
using UnityEngine;
using System.IO;

public class ClearStorage : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
        File.Delete(Application.persistentDataPath + "chapters.bin");
        Application.Quit();
    }
}
