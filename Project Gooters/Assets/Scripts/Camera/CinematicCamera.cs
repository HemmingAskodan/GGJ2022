using UnityEngine;

public class CinematicCamera : MonoBehaviour
{
    public CinematicMode mode;

    private void Awake()
    {
        enabled = false;
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