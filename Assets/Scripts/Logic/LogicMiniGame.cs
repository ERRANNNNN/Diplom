using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LogicMiniGame : MonoBehaviour
{
    [SerializeField] private Image[] _Hearts = new Image[3];
    [SerializeField] private Sprite ActiveHeart;
    [SerializeField] private Sprite BrokenHeart;
    [SerializeField] private GameObject _WinLoseObj;
    [SerializeField] private WinLoseLogic _WinLose;
    [SerializeField] private Crystall[] Crystalls;
    [SerializeField] private LogicLevel[] Levels;
    private static int CurrentLevelId = 0;
    private static LogicLevel CurrentLevel;
    private static Crystall CurrentCrystall;
    public static bool isLevelNextExists { get => (CurrentLevelId + 1) != StaticLevels.Length; }
    private static GameObject _WinLoseObjStatic;
    private static WinLoseLogic _WinLoseStatic;
    private static LogicLevel[] StaticLevels;
    private static Crystall[] StaticCrystalls;
    public static LogicMiniGame Me;
    public static int time = 0;
    [SerializeField] private TextMeshProUGUI timerObj;

    void Start()
    {
        Me = this;
        StartTimer();
        StaticLevels = Levels;
        StaticCrystalls = Crystalls;
        _WinLoseObjStatic = _WinLoseObj;
        _WinLoseStatic = _WinLose;
        CurrentLevel = StaticLevels[CurrentLevelId];
        CurrentCrystall = StaticCrystalls[CurrentLevelId];
        InitializeHearts();
    }

    private static void InitLevel()
    {
        CurrentLevel = StaticLevels[CurrentLevelId];
        CurrentLevel.gameObject.SetActive(true);
        CurrentCrystall = StaticCrystalls[CurrentLevelId];
        CurrentCrystall.Init();
        CurrentLevel.Init();
    }

    private IEnumerator Timer()
    {
        while(true)
        {
            time++;
            timerObj.text = time.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void StopTimer()
    {
        StopCoroutine("Timer");
    }

    public void StartTimer()
    {
        StartCoroutine("Timer");
    }

    private void InitializeHearts()
    {
        for(int i = 2; i >= 0; i--)
        {
            ChangeHeart(_Hearts[i], i <= (Storage.logicHearts-1));
        }
    }

    private void ChangeHeart(Image heart, bool isAlive)
    {
        if (isAlive)
        {
            heart.sprite = ActiveHeart;
        }
        else
        {
            heart.sprite = BrokenHeart;
            heart.color = new Color(1, 1, 1, 0.5f);
        }
        
    }

    public static void Win()
    {
        Me.StopTimer();
        _WinLoseObjStatic.SetActive(true);
        _WinLoseStatic.Init(true);
    }

    public static void NextLevel()
    {
        CurrentLevel.gameObject.SetActive(false);
        CurrentLevelId++;
        InitLevel();
        _WinLoseObjStatic.SetActive(false);
        Me.StartTimer();
    }

    public static void LoseHeart()
    {
        Storage.logicHearts--;
        if (Storage.logicHearts == 0)
        {
            Me.StopTimer();
            time = 0;
            _WinLoseObjStatic = Me._WinLoseObj;
            _WinLoseStatic = Me._WinLose;
            _WinLoseObjStatic.SetActive(true);
            _WinLoseStatic.Init(false);
            CurrentLevelId = 0;
        } else {
            CurrentLevel.gameObject.SetActive(true);
            InitLevel();
            Me.InitializeHearts();
        }
    }
}
