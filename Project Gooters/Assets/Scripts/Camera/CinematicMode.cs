using UnityEngine;

public abstract class CinematicMode : MonoBehaviour
{
    public abstract void Init();
    public abstract void Run();
    public abstract void Terminate();
}