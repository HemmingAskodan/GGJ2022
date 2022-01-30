using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GroovySongSingleton : MonoBehaviour
{
    private static GroovySongSingleton instance;
    public static GroovySongSingleton Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource GetAudioSource()
    {
        return GetComponent<AudioSource>();
    }

    void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
