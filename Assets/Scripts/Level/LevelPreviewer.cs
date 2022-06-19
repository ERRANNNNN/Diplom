using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelPreviewer: MonoBehaviour, IPointerClickHandler
{
    private Level _Level;
    [SerializeField] private TextMeshProUGUI _Number;
    [SerializeField] private TextMeshProUGUI _Theme;
    [SerializeField] private Image _Image;
    [SerializeField] private Stars _Stars;

    private Color ColorCompleted = new Color(1, 1, 1, 0.5f);
    private Color ColorUncompleted = new Color(1,1,1,1);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_Level.isCompleted)
        {
            AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap 1");
            AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
            Storage.CurrentLevel = _Level;
            Loading.LoadScene("Level2");
        }
    }

    public void Init(Level level, int number)
    {
        _Level = level;
        _Number.text = "Уровень " + (number + 1).ToString();
        _Theme.text = _Level.Name;

        ChangeColor(_Level.isCompleted);
        _Stars.Initialize(_Level.stars);
    }

    private void ChangeColor(bool levelIsCompleted)
    {
        if (levelIsCompleted)
            _Image.color = ColorCompleted;
        else
            _Image.color = ColorUncompleted;
    }
}
