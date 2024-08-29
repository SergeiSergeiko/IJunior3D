using System;
using UnityEngine;

public class SettingsControl : MonoBehaviour
{
    [field: SerializeField] public KeyCode Left { get; private set; } = KeyCode.A;
    [field: SerializeField] public KeyCode Right { get; private set; } = KeyCode.D;
    [field: SerializeField] public KeyCode Up { get; private set; } = KeyCode.W;
    [field: SerializeField] public KeyCode Down { get; private set; } = KeyCode.S;
    [field: SerializeField] public KeyCode Attack { get; private set; } = KeyCode.Mouse0;
}