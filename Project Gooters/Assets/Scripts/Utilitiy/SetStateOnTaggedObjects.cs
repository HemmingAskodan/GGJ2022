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
                obj.SetActive(state);
            }
        }
    }
}