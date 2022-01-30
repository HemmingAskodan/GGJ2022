using UnityEngine;

public abstract class FootSteps : MonoBehaviour
{
    public AudioSource source;

    public abstract void PlaySound();

    public virtual void StopSound()
    {
    }
}