using UnityEngine;
using UnityEngine.Events;

public class AnimationKeyEventExecuter : MonoBehaviour
{
    public UnityEvent[] triggeredEvents;

    public void TriggerAnimationEvent(int index)
    {
        triggeredEvents[index].Invoke();
    }
}