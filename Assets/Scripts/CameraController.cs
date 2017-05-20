using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    private Transform[] targets;
    private Transform topBorder;
    private Transform bottomBorder;
    private Transform leftBorder;
    private Transform rightBorder;

    public float verticalOffset = 2f;
    public float dampTime = 0.2f;
    public float screenEdgeBuffer = 4f;
    public float minZoom = 7.4f;

    private Camera cam;

    private Vector3 currentVelocity;
    private Vector3 desiredPosition;
    private float currentZoomVelocity;
    private float desiredZoom;

    public bool finalMovement = false;
    
	void Start () {
        targets = new Transform[2];

        cam = GetComponent<Camera>();
        targets[0] = GameObject.FindGameObjectWithTag("Yang").transform;
        targets[1] = GameObject.FindGameObjectWithTag("Yin").transform;
        topBorder = gameObject.transform.GetChild(0);
        bottomBorder = gameObject.transform.GetChild(1);
        leftBorder = gameObject.transform.GetChild(2);
        rightBorder = gameObject.transform.GetChild(3);
    }
	
	void Update () {
        desiredPosition = FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, dampTime);

        if (!finalMovement) {
            transform.position = new Vector3
                (
                    Mathf.Clamp(transform.position.x, leftBorder.localPosition.x, rightBorder.localPosition.x),
                    Mathf.Clamp(transform.position.y, bottomBorder.localPosition.y, topBorder.localPosition.y),
                    transform.position.z
                );
        }
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

    public void LevelOverMovement() {
        verticalOffset = 0f;
        screenEdgeBuffer = 1.25f;
        desiredZoom = FindNeededZoom();
        finalMovement = true;
    }

    public void Zoom() {
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, desiredZoom, ref currentZoomVelocity, dampTime);
    }

    float FindNeededZoom() {
        // get local position of where we wana move
        Vector3 desiredLocalPosition = transform.InverseTransformPoint(transform.position);
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

        zoom = Mathf.Min(zoom, minZoom);

        return zoom;
    }
}
