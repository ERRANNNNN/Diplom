using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static string PlaneName = "Menu";

    [SerializeField] private GameObject _Menu;
    [SerializeField] private GameObject _Chapters;
    [SerializeField] private GameObject _Levels;

    private void Start()
    {
        Storage.CurrentChapter = Storage.Chapters[0];

        switch(PlaneName)
        {
            case "Menu":
                _Menu.SetActive(true);
                break;
            case "Chapters":
                _Chapters.SetActive(true);
                break;
            case "Levels":
                _Levels.SetActive(true);
                break;
        }
    }
}
