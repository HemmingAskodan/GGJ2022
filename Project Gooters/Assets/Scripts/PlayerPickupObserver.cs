using UnityEngine;

public class PlayerPickupObserver : MonoBehaviour
{
    private Pickup _currentPickup;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var found = col.GetComponent<Pickup>();
        if (found)
        {
            _currentPickup = found;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currentPickup = null;
    }

    public bool GetItem(out Pickup pickup)
    {
        pickup = _currentPickup;
        return pickup != null;
    }
}