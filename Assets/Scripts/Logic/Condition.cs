using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> paths;

    private List<IOutput> outputs;
}
