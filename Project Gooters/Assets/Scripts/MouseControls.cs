using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseControls : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public SpriteRenderer render;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var velocity = _rigidbody.velocity;
        velocity.x = _direction.x * Time.deltaTime * speed;

        _rigidbody.velocity = velocity;
    }

    private void OnMove(InputValue value)
    {
        _direction = value.Get<Vector2>();

        render.flipX = _direction.x switch
        {
            < 0 => false,
            > 0 => true,
            _ => render.flipX
        };
    }
}