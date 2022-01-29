using System.Linq;
using UnityEngine;

public class ComponentDetection : MonoBehaviour
{
    private const int MaxNumberOfElementsToCheck = 5;

    public LayerMask detectionMask;
    public Transform detectionPoint;
    public float detectionRadius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }

    public bool SearchForComponent<TComponent>(out TComponent foundComponent) where TComponent : Component
    {
        foundComponent = null;
        var relativePos = (Vector2) detectionPoint.position;

        var overlaps = new Collider2D[MaxNumberOfElementsToCheck];
        var foundAmount = Physics2D.OverlapCircleNonAlloc(relativePos, detectionRadius, overlaps, detectionMask);

        var components = overlaps
            .Take(foundAmount)
            .Select(overlap => overlap.GetComponent<TComponent>())
            .Where(pickup => pickup != null)
            .ToList();

        var currentDistance = 10000.0f;
        foreach (var pickup in components)
        {
            var distance = (relativePos - (Vector2) pickup.transform.position).sqrMagnitude;
            if (!(currentDistance > distance))
            {
                continue;
            }

            currentDistance = distance;
            foundComponent = pickup;
        }

        return foundComponent != null;
    }
}