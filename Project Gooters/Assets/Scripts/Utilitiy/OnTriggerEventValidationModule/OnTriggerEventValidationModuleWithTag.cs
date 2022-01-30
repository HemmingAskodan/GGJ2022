using UnityEngine;

public class OnTriggerEventValidationModuleWithTag : OnTriggerEventValidationModule
{
    public string tag;

    public override bool Validate(GameObject onEnteredObject)
    {
        return onEnteredObject.CompareTag(tag);
    }
}