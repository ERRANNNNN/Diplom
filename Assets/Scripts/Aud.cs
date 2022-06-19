using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Aud : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite withAud;
    [SerializeField] private Sprite withoutAud;

    private void Start()
    {
        ChangeSprite();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
        if (Storage.Volume == 1)
        {
            Storage.Volume = 0;
        } else
        {
            Storage.Volume = 1;            
        }
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if(Storage.Volume == 1)
        {
            _image.sprite = withAud;
        } else
        {
            _image.sprite = withoutAud;
        }
    }
}
