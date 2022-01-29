using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    [Header("Jumping")] public float jumpForce;
    public Vector2 groundOffset;
    public float groundCheckRadius;
    public LayerMask groundCheckMask;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private float _scaleX;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        var velocity = _rigidbody.velocity;
        velocity.x = _direction.x * movementSpeed;
        _rigidbody.velocity = velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (Vector3) groundOffset, groundCheckRadius);
    }

    private void OnMove(InputValue value)
    {
        _direction = value.Get<Vector2>();

        switch (_direction.x)
        {
            case > 0.0f:
            {
                FlipImage(-_scaleX);
                break;
            }
            case < 0.0f:
            {
                FlipImage(_scaleX);
                break;
            }
        }
    }

    private void OnJump()
    {
        var relativePos = (Vector2) transform.position + groundOffset;

        if (!Physics2D.OverlapCircle(relativePos, groundCheckRadius, groundCheckMask))
        {
            return;
        }

        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FlipImage(float dirX)
    {
        var trans = transform;
        var scale = trans.localScale;
        scale.x = dirX;
        trans.localScale = scale;
    }
}