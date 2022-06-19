using UnityEngine;
using TMPro;

public class WinLoseLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _WinLoseText;
    [SerializeField] private GameObject NextButton;
    [SerializeField] private TextMeshProUGUI _Time;

    public void Init(bool isWin)
    {
        if (isWin) {
            _WinLoseText.text = "Победа!";
            AudioClip sound = Resources.Load<AudioClip>("Sounds/Win");
            AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
            if (LogicMiniGame.isLevelNextExists)
            {
                NextButton.SetActive(true);
                _Time.text = "";
            } else {
                _Time.text = "Вы прошли все уровни за " + LogicMiniGame.time.ToString() + " секунд(у)!";
                NextButton.SetActive(false);
            }
        } else {
            AudioClip sound = Resources.Load<AudioClip>("Sounds/Lose");
            AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0), Storage.Volume);
            _WinLoseText.text = "Вы проиграли...";
            _Time.text = "";
            NextButton.SetActive(false);
        }
    }
}
