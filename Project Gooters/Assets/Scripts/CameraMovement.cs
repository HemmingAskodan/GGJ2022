using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState {FindMiddle, Room}

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    public CameraState cameraState = CameraState.FindMiddle;
    public Vector3 betweenOffset;
    static private CameraMovement instance;
    static public CameraMovement Instance(){
        return instance;
    }

    private Transform gooseTransform;
    private Transform mouseTransform;
    private Camera camera => GetComponent<Camera>();

    private Vector3 centerRoom = new Vector3();
    private float zoomCamera = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            gooseTransform = GameObject.FindGameObjectWithTag("Goose").transform;
            mouseTransform = GameObject.FindGameObjectWithTag("Mouse").transform;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3();
        float cameraSize = 5f;
        Vector3 dept = Vector3.back * 10;
        if(cameraState == CameraState.FindMiddle)
        {
            Vector3 vDistance = mouseTransform.position - gooseTransform.position;
            Vector3 between = (gooseTransform.position + vDistance / 2) + betweenOffset;
            target = between + dept;
            cameraSize = (vDistance.magnitude / 2) + 2;
        }

        if(cameraState == CameraState.Room)
        {
            target = centerRoom + dept;
            cameraSize = zoomCamera;
        }

        transform.position = Vector3.Lerp(transform.position, target,0.01f);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,cameraSize,0.01f);
    }

    public void SetRoom(Vector3 centerRoom, float zoomCamera = 5f)
    {
        cameraState = CameraState.Room;
        this.centerRoom = centerRoom;
        this.zoomCamera = zoomCamera;
    }
}
