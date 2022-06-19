using UnityEngine;

public class BackToMenuFromTest : MonoBehaviour
{
    public void BackToMenu()
    {
        AudioClip sound = Resources.Load<AudioClip>("Sounds/Wood Tap");
        AudioSource.PlayClipAtPoint(sound, new Vector3(0, 0, 0),Storage.Volume);
        MainMenu.PlaneName = "Chapters";
        Loading.LoadScene("MainMenu");
    }
}
