using UnityEngine;

public class FootStepsMultiple : FootSteps
{
    public AudioClip[] clips;

    private void Awake()
    {
        source.clip = clips[0];
    }

    public override void PlaySound()
    {
        if (source.isPlaying)
        {
            return;
        }

        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
    }
}