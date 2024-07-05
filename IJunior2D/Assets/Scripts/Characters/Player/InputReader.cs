using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public event Action Went;
    public event Action Jumped;
    public event Action Attacked;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            Went?.Invoke();

        if (Input.GetKeyDown(KeyCode.W))
            Jumped?.Invoke();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attacked?.Invoke();
    }

    public float GetAxisDirection() => Input.GetAxis(Horizontal);
}