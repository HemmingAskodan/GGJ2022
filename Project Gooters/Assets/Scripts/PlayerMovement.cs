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
    private bool controlsEnabled = true;
    private float gravityScale;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
        gravityScale = GetComponent<Rigidbody2D>().gravityScale;
    }

    void OnEnable(){
        if(gameObject.tag == "Goose")
        {
            CameraMovement.Instance().SetGooseTransform(transform);
        }
        if(gameObject.tag == "Mouse")
        {
            CameraMovement.Instance().SetMouseTransform(transform);
        }
    }

    public void CustomEnable(bool enable)
    {
        controlsEnabled = enable;
        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(sr == null)
        {
            sr = GetComponentInChildren<SpriteRenderer>();
        }
        if(sr != null)
        {
            sr.enabled = enable;
        }

        // Collider2D c2D = GetComponent<Collider2D>();
        // if(c2D == null)
        // {
        //     c2D = GetComponentInChildren<Collider2D>();
        // }
        // if(c2D != null)
        // {
        //     c2D.enabled = enable;
        // }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            rb = GetComponentInChildren<Rigidbody2D>();
        }
        if(rb != null)
        {
            if(enable)
                rb.bodyType = RigidbodyType2D.Dynamic;
            else
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = Vector2.zero;
            }
        }
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
        if(!controlsEnabled)
            return;

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
        if(!controlsEnabled)
            return;

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