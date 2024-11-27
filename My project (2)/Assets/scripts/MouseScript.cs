using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private Camera Cam;

    public float TargetZoom = 3; // The value to zoom to
    private float ScrollData; // Float collector for scroll input

    public float ZoomSpeed = 3; // Speed of zooming

    void Start()
    {
        Cam = GetComponent<Camera>();
        TargetZoom = Cam.orthographicSize;
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        // When the Mouse is still, this function returns 0. Forward scrolling returns a positive value, Backward scrolling returns a negative value.
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        TargetZoom = TargetZoom - ScrollData;
        TargetZoom = Mathf.Clamp(TargetZoom, 3, 6);
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}
