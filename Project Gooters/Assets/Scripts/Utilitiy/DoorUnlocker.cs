using UnityEngine;

public class DoorUnlocker : MonoBehaviour
{
    public GameObject key;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != key)
        {
            return;
        }

        key.SetActive(false);
        gameObject.SetActive(false);
    }
}