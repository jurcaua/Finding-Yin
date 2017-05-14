using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    public Transform[] targets;
    
    public float verticalOffset = 2f;
    public float dampTime = 0.2f;
    public float screenEdgeBuffer = 4f;
    public float minZoom = 6.5f;

    private Camera cam;

    private Vector3 currentVelocity;
    private Vector3 desiredPosition;
    private float currentZoomVelocity;
    private float desiredZoom;
    
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	void Update () {
        desiredPosition = FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, dampTime);

        desiredZoom = FindNeededZoom();
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, desiredZoom, ref currentZoomVelocity, dampTime);
	}

    Vector3 FindAveragePosition() {
        Vector3 averagePosition = Vector3.zero;
        for (int i = 0; i < targets.Length; i++) {
            averagePosition += targets[i].position;
        }

        if (targets.Length > 0) {
            averagePosition /= targets.Length;
        }
        averagePosition.y += verticalOffset;
        averagePosition.z = transform.position.z;
        return averagePosition;
    }

    float FindNeededZoom() {
        // get local position of where we wana move
        Vector3 desiredLocalPosition = transform.InverseTransformPoint(desiredPosition);
        desiredLocalPosition.z = 0f;

        float zoom = 0f;
        for (int i = 0; i < targets.Length; i++) {
            // find local point of this target
            Vector3 targetLocalPosition = transform.InverseTransformPoint(targets[i].position);
            targetLocalPosition.z = 0f;

            // find distance from the averaged out desired position
            Vector3 posToTarget = targetLocalPosition - desiredLocalPosition;

            zoom = Mathf.Max(zoom, posToTarget.magnitude);
        }

        zoom += screenEdgeBuffer;

        zoom = Mathf.Max(zoom, minZoom);

        return zoom;
    }
}
