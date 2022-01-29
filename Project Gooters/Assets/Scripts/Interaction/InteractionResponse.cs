using UnityEngine;
using UnityEngine.Events;

public class InteractionResponse : MonoBehaviour
{
    public UnityEvent onActionTriggered;

    public void Interact()
    {
        onActionTriggered.Invoke();
    }
}