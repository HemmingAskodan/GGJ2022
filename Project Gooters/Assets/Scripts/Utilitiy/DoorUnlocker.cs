using UnityEngine;

public class DoorUnlocker : MonoBehaviour
{
    public GameObject key;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + key.name);
        if (col.gameObject != key)
        {
            return;
        }

        key.SetActive(false);
        gameObject.SetActive(false);
    }
}