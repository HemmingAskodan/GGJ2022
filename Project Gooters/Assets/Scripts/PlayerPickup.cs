using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [Header("Pickup")] public Transform pickupPoint;
    public ComponentDetection detection;

    private Pickup _currentItem;

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        if (_currentItem == null)
        {
            return;
        }

        _currentItem.UpdateTarget(pickupPoint.position);
    }

    public void OnPickup()
    {
        // if currently don't hold an item, then try and grab one
        if (!_currentItem)
        {
            if (!detection.SearchForComponent(out Pickup pickup))
            {
                return;
            }

            _currentItem = pickup;
            _currentItem.PickupItem();
            enabled = true;
            return;
        }

        _currentItem.DropItem();
        _currentItem = null;
        enabled = false;
    }
}