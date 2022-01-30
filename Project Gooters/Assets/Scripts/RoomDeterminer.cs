using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDeterminer : MonoBehaviour
{
    public Vector2 center;
    public float cameraZoom = 6.75f;

    bool mouseInside = false, gooseInside = false;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Mouse")
        {
            mouseInside = true;
        }
        if(collider2D.tag == "Goose")
        {
            gooseInside = true;
        }
        if(mouseInside && gooseInside)
        {
            CameraMovement.Instance().SetRoom(center,cameraZoom);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Mouse")
        {
            mouseInside = false;
        }
        if(collider2D.tag == "Goose")
        {
            gooseInside = false;
        }

        {
            CameraMovement.Instance().cameraState = CameraState.FindMiddle;
        }
    }
}
