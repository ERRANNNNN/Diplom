using UnityEngine;
using UnityEditor;

[SerializeField]
public interface IInput
{
    void Get(IOutput output = null, bool active = false);
}