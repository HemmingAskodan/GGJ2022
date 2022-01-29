using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TargetJoint2D))]
public class Pickup : MonoBehaviour
{
    public UnityEvent onPickedUp;
    public UnityEvent onDropped;
    private Collider2D _collider;

    private Rigidbody2D _rigidbody;
    private TargetJoint2D _target;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _target = GetComponent<TargetJoint2D>();

        _target.enabled = false;
    }

    public void UpdateTarget(Vector2 point)
    {
        _target.target = point;
    }

    public void PickupItem()
    {
        // _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector2.zero;
        _collider.enabled = false;
        _target.enabled = true;
        onPickedUp.Invoke();
    }

    public void DropItem()
    {
        _collider.enabled = true;
        _target.enabled = false;
        onDropped.Invoke();
    }
}