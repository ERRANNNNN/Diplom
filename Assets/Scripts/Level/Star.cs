using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [SerializeField] private Sprite _Active;
    [SerializeField] private Sprite _Unactive;
    [SerializeField] private Image _Image;

    public void ChangeState(bool isActive)
    {
        if (isActive) _Image.sprite = _Active;
        else _Image.sprite = _Unactive;
    }
}
