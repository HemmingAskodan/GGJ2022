using UnityEngine;

public class DisableContainedObject : MonoBehaviour
{
    private GameObject _foundItems;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _foundItems = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _foundItems = other.gameObject;
    }

    public void Disable()
    {
        if (_foundItems)
        {
            _foundItems.SetActive(false);
        }
    }
}