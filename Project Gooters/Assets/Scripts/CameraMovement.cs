using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState {FindMiddle, Room}

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    public CameraState cameraState = CameraState.FindMiddle;
    public Vector3 betweenOffset = new Vector3(0,0.5f,0);
    public float betweenZoom = 6.75f;
    static private CameraMovement instance;
    static public CameraMovement Instance(){
        return instance;
    }

    private Transform gooseTransform;
    private Transform mouseTransform;
    public void SetGooseTransform(Transform t)
    {
        gooseTransform = t;
    }
    public void SetMouseTransform(Transform t)
    {
        mouseTransform = t;
    }
    private Camera camera => GetComponent<Camera>();

    private Vector3 centerRoom = new Vector3();
    private float roomZoomCamera = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            // gooseTransform = GameObject.FindGameObjectWithTag("Goose").transform;
            // mouseTransform = GameObject.FindGameObjectWithTag("Mouse").transform;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gooseTransform && mouseTransform)
        {
            Vector3 target = new Vector3();
            float cameraSize = 5f;
            Vector3 dept = Vector3.back * 10;
            if(cameraState == CameraState.FindMiddle)
            {
                Vector3 vDistance = mouseTransform.position - gooseTransform.position;
                Vector3 between = (gooseTransform.position + vDistance / 2) + betweenOffset;
                target = new Vector3(between.x, transform.position.y ,dept.z);
                // cameraSize = (vDistance.magnitude / 2) + 2;
                cameraSize = betweenZoom;
            }

            if(cameraState == CameraState.Room)
            {
                target = centerRoom + dept;
                cameraSize = roomZoomCamera;
            }

            transform.position = Vector3.Lerp(transform.position, target,0.01f);
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,cameraSize,0.01f);
        }
    }

    public void SetRoom(Vector3 centerRoom, float zoomCamera = 5f)
    {
        cameraState = CameraState.Room;
        this.centerRoom = centerRoom;
        this.roomZoomCamera = zoomCamera;
    }

    void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
