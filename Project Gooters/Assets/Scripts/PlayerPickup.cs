using System.Linq;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private const int MaxNumberOfElementsToCheck = 5;

    [Header("Pickup Detection")] public LayerMask pickupMask;
    public Transform pickupDetectionPoint;
    public float pickupCheckRadius;

    [Header("Pickup")] public Transform pickupPoint;

    private Pickup _currentItem;

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        _currentItem.UpdateTarget(pickupPoint.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(pickupDetectionPoint.position, pickupCheckRadius);
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
            enabled = true;
            return;
        }

        _currentItem.DropItem();
        _currentItem = null;
        enabled = false;
    }

    private bool SearchForItem(out Pickup foundPickup)
    {
        foundPickup = null;
        var relativePos = (Vector2) pickupDetectionPoint.position;

        var overlaps = new Collider2D[MaxNumberOfElementsToCheck];
        var foundAmount = Physics2D.OverlapCircleNonAlloc(relativePos, pickupCheckRadius, overlaps, pickupMask);

        var pickups = overlaps
            .Take(foundAmount)
            .Select(overlap => overlap.GetComponent<Pickup>())
            .Where(pickup => pickup != null)
            .ToList();

        var currentDistance = 10000.0f;
        foreach (var pickup in pickups)
        {
            var distance = (relativePos - (Vector2) pickup.transform.position).sqrMagnitude;
            if (!(currentDistance > distance))
            {
                continue;
            }

            currentDistance = distance;
            foundPickup = pickup;
        }

        return foundPickup != null;
    }
}