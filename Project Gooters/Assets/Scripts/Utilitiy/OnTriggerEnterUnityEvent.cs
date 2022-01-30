using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterUnityEvent : MonoBehaviour
{
    public bool disableObjectOnTrigger;
    public UnityEvent OnTriggered;

    private OnTriggerEventValidationModule[] _modules;

    private void Start()
    {
        _modules = GetComponents<OnTriggerEventValidationModule>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_modules.Any(module => !module.Validate(col.gameObject)))
        {
            return;
        }

        if (disableObjectOnTrigger)
        {
            col.gameObject.SetActive(false);
        }

        OnTriggered.Invoke();
    }
}