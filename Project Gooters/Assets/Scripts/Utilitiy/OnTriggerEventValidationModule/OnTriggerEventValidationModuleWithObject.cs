using UnityEngine;

public class OnTriggerEventValidationModuleWithObject : OnTriggerEventValidationModule
{
    public GameObject matchedObject;

    public override bool Validate(GameObject onEnteredObject)
    {
        return onEnteredObject == matchedObject;
    }
}