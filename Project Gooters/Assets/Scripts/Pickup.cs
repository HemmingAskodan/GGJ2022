using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pickup : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void PickupItem()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
    }

    public void DropItem()
    {
        _rigidbody.isKinematic = false;
    }
}