using UnityEngine;

public class CinematicCamera : MonoBehaviour
{
    public bool initializeOnAwake;
    public CinematicMode mode;

    private void Awake()
    {
        enabled = false;
        if (initializeOnAwake)
        {
            Initialize();
        }
    }

    private void Update()
    {
        mode.Run();
    }

    public void Initialize()
    {
        mode.Init();
        enabled = true;
    }
}