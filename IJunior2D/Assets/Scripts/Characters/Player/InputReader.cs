using System;
using UnityEngine;

[RequireComponent(typeof(SettingsControl))]
public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    private SettingsControl _settingsControl;

    public event Action Went;
    public event Action Jumped;
    public event Action Attacked;

    private void Start()
    {
        _settingsControl = GetComponent<SettingsControl>();
    }

    private void Update()
    {
        if (Input.GetKey(_settingsControl.Left) || Input.GetKey(_settingsControl.Right))
            Went?.Invoke();

        if (Input.GetKeyDown(_settingsControl.Up))
            Jumped?.Invoke();

        if (Input.GetKeyDown(_settingsControl.Attack))
            Attacked?.Invoke();
    }

    public float GetAxisDirection() => Input.GetAxis(Horizontal);
}