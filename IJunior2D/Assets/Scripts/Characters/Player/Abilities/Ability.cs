using System;
using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] protected KeyCode ActivateButton;

    protected Coroutine Countdowning;

    public event Action<float> ActionTimeChanged;

    private event Action ReloadOver;
    private event Action CountdownActiveTimeOver;

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

    protected void CountdownActiveTime()
    {
        float start = 0f;
        float end = 1f;

        RunCoroutineIfNotRunning(Countdown(start, end, CountdownActiveTimeOver),
            Countdowning);
    }

    protected void Reload()
    {
        float start = 1f;
        float end = 0f;

        RunCoroutineIfNotRunning(Countdown(start, end, ReloadOver), Countdowning);
    }

    protected void RunCoroutineIfNotRunning(IEnumerator routine, Coroutine coroutine)
    {
        if (coroutine == null)
            coroutine = StartCoroutine(routine);
    }

    private IEnumerator Countdown(float start, float end, Action countdownOver)
    {
        float elapsedTime = 0f;
        float currentTime;

        while (elapsedTime < Duraction)
        {
            elapsedTime += Time.deltaTime;

            currentTime = Mathf.Lerp(start, end, elapsedTime / Duraction);
            ActionTimeChanged?.Invoke(currentTime);

            yield return null;
        }

        countdownOver?.Invoke();
    }

    private void ReloadOverHandler()
    {
        CanActivate = true;
    }
    
    private void CountdownActiveTimeOverHandler()
    {
        IsActive = false;
    }
}