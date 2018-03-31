using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    private Vector3 velocity = Vector3.zero;

    public float smoothTime;

    public Transform target;

    public bool isInBounds;

    Camera cam;

    public Vector3 minCameraPosition, maxCameraPosition;
    private float cameraZPosition = -10f;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        float camXPos = cam.transform.position.x;
        float camYPos = cam.transform.position.y;
       
        isInBounds = (camXPos >= minCameraPosition.x
            && camYPos >= minCameraPosition.y
            && camXPos <= maxCameraPosition.x
            && camYPos <= maxCameraPosition.y) ? true : false;

        Vector3 targetPosition = target.position;

        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        if (isInBounds)
        {
            float clampX = Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x);
            float clampY = Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y);
            float clampZ = Mathf.Clamp(transform.position.z, minCameraPosition.z, cameraZPosition);
            transform.position = new Vector3(clampX, clampY, clampZ);
        }

        
    }
}
