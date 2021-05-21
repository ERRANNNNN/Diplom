using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelPreviewer: MonoBehaviour, IPointerClickHandler
{
    private Level _Level;
    [SerializeField]
    private TextMeshProUGUI _Number;
    [SerializeField]
    private TextMeshProUGUI _Theme;
    [SerializeField]
    private Image _Image;
    [SerializeField]
    private TextMeshProUGUI _Completed;

    private Color ColorCompleted = new Color(0.56f, 0.58f, 0.6f);
    private Color ColorUncompleted = new Color(0.29f, 0.6f, 0.2f);

    public void Init(Level level, int number)
    {
        _Level = level;
        _Number.text = "Уровень " + (number + 1).ToString();
        _Theme.text = _Level.Name;
        if(_Level.isCompleted)
        {
            _Completed.text = "Пройден";
            _Image.color = ColorCompleted;
        } else {
            _Completed.text = "";
            _Image.color = ColorUncompleted;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_Level.isCompleted)
        {
            Storage.CurrentLevel = _Level;
            Loading.LoadScene("Level");
        }
    }
}
