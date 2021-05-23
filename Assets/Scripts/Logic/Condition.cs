using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Condition : MonoBehaviour, IInput
{
    [SerializeField]
    private List<GameObject> inputsPaths;

    [SerializeField]
    private List<GameObject> outputsPaths;

    [SerializeField]
    private string operation;

    private List<IOutput> inputs;

    private List<IInput> outputs;

    private bool[] inputsActives;

    void Start()
    {
        inputs = inputsPaths.Select(x => x.GetComponent<IOutput>()).ToList();
        outputs = outputsPaths.Select(x => x.GetComponent<IInput>()).ToList();
        inputsActives = new bool[inputs.Count];
    }

    public void Get(IOutput output = null, bool active = false)
    {
        inputsActives[inputs.IndexOf(output)] = active;
        Check();
    }

    private void Check()
    {
        bool finalBool = false;
        switch(operation)
        {
            case "and":
                finalBool = And();
                break;
            case "or":
                finalBool = Or();
                break;
            case "not":
                finalBool = Not();
                break;
        }

        foreach(IInput input in outputs)
        {
            input.Get(default,finalBool);
        }
    }

    private bool And()
    {
        bool finalBool = inputsActives[0];
        for(int i = 1; i < inputsActives.Length; i++)
        {
            finalBool = (finalBool && inputsActives[i]);
        }
        return finalBool;
    }

    private bool Or()
    {
        bool finalBool = inputsActives[0];
        for(int i = 1; i <inputsActives.Length; i++)
        {
            finalBool = (finalBool || inputsActives[i]);
        }
        return finalBool;
    }

    private bool Not()
    {
        return !inputsActives[0];
    }
}
