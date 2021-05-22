using UnityEngine;
using UnityEditor;

[SerializeField]
public interface IOutput
{
    void Send(IInput input = null, bool active = false);
}