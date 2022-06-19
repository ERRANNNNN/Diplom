using System.Collections;
using UnityEngine;

public class LogicLevel : MonoBehaviour
{
    [SerializeField] private Turner[] Turners;
    [SerializeField] private Turner[] ActiveTurners;

    public void Init()
    {
        StartCoroutine(WaitInit());
    }

    public void Off()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator WaitInit()
    {
        yield return new WaitForSeconds(1);
        foreach (Turner turner in Turners)
        {
            turner.GetInputs();
            turner.ChangeActive(false);
        }

        foreach (Turner turner in ActiveTurners)
        {
            turner.ChangeActive(true);
        }
        gameObject.SetActive(true);
    }
}
