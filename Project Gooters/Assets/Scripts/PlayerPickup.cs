using System.Linq;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private const int MaxNumberOfElementsToCheck = 5;

    public LayerMask pickupMask;
    public Transform pickupPoint;
    public float pickupCheckRadius;

    public PlayerPickupObserver pickupObserver;
    private Pickup _currentItem;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(pickupPoint.position, pickupCheckRadius);
    }

    public void OnPickup()
    {
        // if currently don't hold an item, then try and grab one
        if (!_currentItem)
        {
            if (!SearchForItem(out var pickup))
            {
                return;
            }

            _currentItem = pickup;
            _currentItem.PickupItem();
            return;
        }

        _currentItem.DropItem();
        _currentItem = null;
    }

    private bool SearchForItem(out Pickup foundPickup)
    {
        foundPickup = null;
        var relativePos = (Vector2) pickupPoint.position;

        var overlaps = new Collider2D[MaxNumberOfElementsToCheck];
        Physics2D.OverlapCircleNonAlloc(relativePos, pickupCheckRadius, overlaps, pickupMask);

        var pickups = overlaps.Select(overlap => GetComponent<Pickup>()).Where(pickup => pickup != null).ToList();

        var currentDistance = 10000.0f;
        foreach (var overlap in pickups)
        {
            var distance = (relativePos - (Vector2) overlap.transform.position).sqrMagnitude;
            if (!(currentDistance > distance))
            {
                continue;
            }

            currentDistance = distance;
            foundPickup = overlap;
        }

        return foundPickup != null;
    }
}