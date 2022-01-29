using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterUnityEvent : MonoBehaviour
{
    public UnityEvent OnTriggered;

    private void OnTriggerEnter2D(Collider2D col)
    {
        OnTriggered.Invoke();
    }
}