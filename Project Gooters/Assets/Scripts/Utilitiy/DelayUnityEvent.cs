using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayUnityEvent : MonoBehaviour
{
    public UnityEvent afterDelay;
    public float delayInSeconds;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(DelayRoutine());
    }

    private IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(delayInSeconds);
        afterDelay.Invoke();
    }
}