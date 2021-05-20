using UnityEngine.SceneManagement;
using UnityEngine;

public class Loading : MonoBehaviour
{
    private static string SceneToLoadName = "MainMenu";

    void Start()
    {
        SceneManager.LoadSceneAsync(SceneToLoadName);
    }

    public static void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync("Loading");
        SceneToLoadName = name;
    }
}
