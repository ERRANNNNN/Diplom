using UnityEngine;
using TMPro;

public class TestResultsPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Congratulations;
    [SerializeField] private TextMeshProUGUI Results;

    public void Initialize(int all, int correct)
    {
        double percentOfAll = all / 100.0;
        Debug.Log(percentOfAll);
        double percents = 0;

        if (correct != 0)
        {
            percents = correct / percentOfAll;
        }

        Debug.Log(percents);

        if (percents >= 60) {
            Congratulations.text = "Поздравляем!";
            Storage.CurrentLevel.isCompleted = true;
            int stars;

            if(percents < 70)
                stars = 1;
            else if(percents < 80)
                stars = 2;
            else
                stars = 3;

            Storage.CurrentLevel.stars = stars;

        } else {
            Congratulations.text = "Увы, не получилось...";
        }

        Results.text = "Верно: " + correct + " из " + all;
    }
}
