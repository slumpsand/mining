using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{    
    public float cameraMovementSpeed = 10f;
    public float cameraZoomSpeed = 10f;
    [Space]
    public Vector2 cameraPosLimit = new Vector2(-20.5f, 0.5f);
    public Vector2 cameraSizeLimit = new Vector2(4, 6.5f);

    Vector2 maxScrollBuild;    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        maxScrollBuild = new Vector2(-0.5f, 1.5f);
    }

    void Start()
    {
        REF.map.RoomAddedEvent += (_) => CalculateMaxScroll();
    }
    void Update()
    {
        MoveCamera();
        ZoomCamera();

        if(Input.GetMouseButtonUp(1))
        {
            Focus(Input.mousePosition);
        }
    }

    void Focus(Vector2 screenPos)
    {
        Vector3 point = cam.ScreenToWorldPoint(screenPos);
        transform.position = ClampCameraPosition(point);
    }

    void MoveCamera()
    {
        // calculate the new position
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 delta = input * cameraZoomSpeed * Time.deltaTime;
        Vector3 pos = transform.position + new Vector3(delta.x, delta.y);
        
        // set the new position
        transform.position = ClampCameraPosition(pos);
    }

    Vector3 ClampCameraPosition(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, maxScrollBuild.x, maxScrollBuild.y);
        pos.y = Mathf.Clamp(pos.y, cameraPosLimit.x, cameraPosLimit.y);
        pos.z = transform.position.z;

        return pos;
    }

    void ZoomCamera()
    {
        // calculate the new camera size / zoom
        float zoomInput = Input.GetAxisRaw("Zoom");
        float size = cam.orthographicSize + cameraZoomSpeed * Time.deltaTime * -zoomInput;

        // limit the camera zoom
        cam.orthographicSize = Mathf.Clamp(size, cameraSizeLimit.x, cameraSizeLimit.y);
    }

    void CalculateMaxScroll()
    {
        // find the maximum room usage on the left / right
        float leftMaxSize = REF.map.Left.FindMaxSize();
        float rightMaxSize = REF.map.Right.FindMaxSize();

        // add some offsets
        maxScrollBuild = new Vector2(-leftMaxSize - 0.5f, rightMaxSize + 1.5f);
    }

}
