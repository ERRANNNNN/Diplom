using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Splitter : MonoBehaviour, IInput, IOutput
{
    [SerializeField]
    private List<GameObject> OutputPaths;

    private List<IInput> Outputs;

    private void Start()
    {
        Outputs = OutputPaths.Select(x => x.GetComponent<IInput>()).ToList();
    }

    public void Get(IOutput output = null, bool active = false)
    {
        foreach(IInput input in Outputs)
        {
            Send(input, active);
        }
    }

    public void Send(IInput input = null, bool active = false)
    {
        input.Get(default, active);
    }
}
