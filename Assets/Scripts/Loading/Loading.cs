using UnityEngine.SceneManagement;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public static string SceneToLoadName = "MainMenu";

    void Start()
    {
        SceneManager.LoadSceneAsync(SceneToLoadName);
    }
}
