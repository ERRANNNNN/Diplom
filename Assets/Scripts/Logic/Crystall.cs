using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Crystall : MonoBehaviour
{
    public int CurrentPlatformId { private set; get; } = 1;
    [SerializeField] private int FinalPlatformId;

    [SerializeField] private Image _Image;
    [SerializeField] private Sprite AliveSprite;
    [SerializeField] private Sprite BreakSprite;
    [SerializeField] private RectTransform _rect;
    
    public void CheckBreak(int platformId)
    {
        if((platformId - CurrentPlatformId) > 1)
        {
            Break();
            LogicMiniGame.LoseHeart();
        } else {
            if (platformId == FinalPlatformId)
            {
                LogicMiniGame.Win();
            }
            CurrentPlatformId = platformId;
        }
    }

    private void Break()
    {
        _Image.sprite = BreakSprite;
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Glass Breaking");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
    }

    private void Alive()
    {
        CurrentPlatformId = 1;
        _Image.sprite = AliveSprite;
    }

    public void Init()
    {
        StartCoroutine(WaitInit());
    }

    private IEnumerator WaitInit()
    {
        yield return new WaitForSeconds(1);
        Alive();
        _rect.anchoredPosition = new Vector2(0, 0);
    }
}
