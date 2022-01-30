using UnityEngine;

public class FootStepsOne : FootSteps
{
    public AudioClip clip;

    private void Awake()
    {
        source.clip = clip;
    }

    public override void PlaySound()
    {
        source.Play();
    }

    public override void StopSound()
    {
        source.Stop();
    }
}