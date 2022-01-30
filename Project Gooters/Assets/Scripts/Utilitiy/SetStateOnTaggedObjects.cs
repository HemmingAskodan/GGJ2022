using UnityEngine;

public class SetStateOnTaggedObjects : MonoBehaviour
{
    public string[] tags;

    public void SetActive(bool state)
    {
        foreach (var t in tags)
        {
            var obj = GameObject.FindGameObjectWithTag(t);
            if (obj != null)
            {
                PlayerMovement pm = obj.GetComponent<PlayerMovement>();
                if(pm != null)
                {
                    pm.CustomEnable(state);
                }
                else
                {
                    obj.SetActive(state);
                }
            }
        }
    }
}