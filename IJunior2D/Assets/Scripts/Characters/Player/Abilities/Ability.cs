using System;
using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] protected KeyCode ActivateButton;

    protected Coroutine Countdowning;
    protected Coroutine Reloading;

    public event Action<float> ActionTime;

    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public string Description { get; protected set; }
    [field: SerializeField] public int Value { get; protected set; }
    [field: SerializeField] public int Duraction { get; protected set; }
    [field: SerializeField] public int Cooldown { get; protected set; }

    public bool IsActive { get; protected set; } = false;
    public bool CanActivate { get; protected set; } = true;

    protected virtual void Activate()
    {
        IsActive = true;
        CanActivate = false;
    }

    protected IEnumerator Countdown()
    {
        float start = 0f;
        float end = 1f;
        float elapsedTime = 0f;
        float currentTime;

        while (elapsedTime < Duraction)
        {
            elapsedTime += Time.deltaTime;

            currentTime = Mathf.Lerp(start, end, elapsedTime / Duraction);
            ActionTime?.Invoke(currentTime);

            yield return null;
        }

        IsActive = false;
    }

    protected IEnumerator Reload()
    {
        float start = 1f;
        float end = 0f;
        float elapsedTime = 0f;
        float currentTime;

        while (elapsedTime < Cooldown)
        {
            elapsedTime += Time.deltaTime;

            currentTime = Mathf.Lerp(start, end, elapsedTime / Cooldown);
            ActionTime?.Invoke(currentTime);

            yield return null;
        }

        CanActivate = true;
    }

    protected void RunCoroutineIfNotRunning(IEnumerator routine, Coroutine coroutine)
    {
        if (coroutine == null)
            coroutine = StartCoroutine(routine);
    }
}