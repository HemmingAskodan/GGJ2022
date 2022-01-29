using UnityEngine;

public abstract class OnTriggerEventValidationModule : MonoBehaviour
{
    public abstract bool Validate(GameObject onEnteredObject);
}