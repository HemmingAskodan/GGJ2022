using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroovySongManipulator : MonoBehaviour
{
    public float volumeSetTo = 1;
    public float volumeHoldDuration = -1;
    private float actualVolume;
    public bool onStart = true;

    // Start is called before the first frame update
    void Start()
    {
        if(GroovySongSingleton.Instance() != null && onStart)
        {
            Manipulate();
        }
    }

    public void Manipulate()
    {
            actualVolume = GroovySongSingleton.Instance().GetAudioSource().volume;
            GroovySongSingleton.Instance().GetAudioSource().volume = volumeSetTo;
            StartCoroutine(SwitchBack(volumeHoldDuration));
    }

    IEnumerator SwitchBack(float volumeHoldDuration)
    {
        if(volumeHoldDuration >= 0)
        {
            yield return new WaitForSeconds(volumeHoldDuration);
            GroovySongSingleton.Instance().GetAudioSource().volume = actualVolume;
        }
    }
}
