using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float cameraMovementSpeed = 10f;
    public float cameraZoomSpeed = 10f;

    public float minCameraDistance = 5f;
    public float maxCameraDistance = 12f;

    void Update()
    {
        // get the axis input
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        float zoomInput = Input.GetAxisRaw("Zoom");

        // calculate the delta
        Vector3 deltaMovement = cameraMovementSpeed * input * Time.deltaTime;
        Vector3 deltaZoom = Vector3.forward * cameraZoomSpeed * zoomInput * Time.deltaTime;

        // set the new position
        Vector3 pos = transform.position;
        pos += deltaMovement + deltaZoom;
        pos.z = Mathf.Clamp(pos.z, -maxCameraDistance, -minCameraDistance);
        transform.position = pos;
    }

}
