using UnityEngine;

public class ObjectTeleporter : MonoBehaviour
{
    public Transform teleportTo;
    public Vector2 arrivalForce;

    private GameObject _objectToTeleport;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _objectToTeleport = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _objectToTeleport = other.gameObject;
    }

    public void StartTeleporting()
    {
        if (_objectToTeleport)
        {
            _objectToTeleport.SetActive(false);
        }
    }

    public void StopTeleporting()
    {
        if (!_objectToTeleport)
        {
            return;
        }

        var objPos = _objectToTeleport.transform.position;
        var teleportToPos = teleportTo.position;

        objPos.x = teleportToPos.x;
        objPos.y = teleportToPos.y;
        _objectToTeleport.transform.position = objPos;

        _objectToTeleport.SetActive(true);
        var body = _objectToTeleport.GetComponent<Rigidbody2D>();
        if (body)
        {
            body.AddForce(arrivalForce, ForceMode2D.Impulse);
        }
    }
}