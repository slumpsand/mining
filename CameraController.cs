using UnityEngine;

public class CameraController : MonoBehaviour
{    
    public float cameraMovementSpeed = 10f;
    public float cameraZoomSpeed = 10f;
    [Space]
    public float minCameraDistance = 5f;
    public float maxCameraDistance = 12f;
    [Space]
    public float maxCameraUP = 0f;
    Pair<float, float> maxScroll;
    void Start()
    {
        CalculateMaxScroll();
        REF.map.RoomAddedEvent += (room) => CalculateMaxScroll();
    }
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
        // don't let the camera get to close to the screen
        pos.z = Mathf.Clamp(pos.z, -maxCameraDistance, -minCameraDistance);
        // don't let the camera get to far away from the tiles        if (pos.x < maxScroll.Left) pos.x = maxScroll.Left;
        if (pos.x > maxScroll.Right) pos.x = maxScroll.Right;
        // don't let the camera go to far into the sky or into the ground
        if (pos.y > maxCameraUP) pos.y = maxCameraUP;
        transform.position = pos;
    }

    void CalculateMaxScroll()
    {
        Pair<float, float> maxScroll = new Pair<float, float>();
        foreach(Row row in REF.map.Left)
        {
            float size = row.Size();
            if (size > maxScroll.Left)
                maxScroll.Left = size;
        }
        foreach (Row row in REF.map.Right)
        {
            float size = row.Size();
            if (size > maxScroll.Right)
                maxScroll.Right = size;        }
        maxScroll.Left += 0.5f;
        maxScroll.Right += 1.5f;
        maxScroll.Left *= -1;

        this.maxScroll = maxScroll;
    }

}
