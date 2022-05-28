using UnityEngine;
using UnityEngine.InputSystem;

public class PathManager : MonoBehaviour
{
    GameObject player;
    Camera PlayerCam, skippyCam;

    public InputActionAsset vrInputController;
    public InputActionAsset twoDInputController;

    Vector2 pointerPosition, destination;
    Ray ray;
    RaycastHit hit, hit2;

    Manager manager;
    LineRenderer lineRenderer;

    public Vector3 point;
    Vector3 start;

    public bool selected, changed, draw;

    InputAction inputAction;

    void Start()
    {
        manager = transform.parent.GetComponentInChildren<Manager>();
        lineRenderer =  GetComponent<LineRenderer>();

        if (FindObjectOfType<VRDetector>().isVr)
        {
            inputAction = vrInputController.FindActionMap("XRI RightHand").FindAction("Move");
            player = GameObject.Find("VRPlayer(Clone)");
        }          
        else
        {
            inputAction = twoDInputController.FindActionMap("Player").FindAction("Cursor");
            player = GameObject.Find("2DPlayer(Clone)");
        }

    }

    public void OnClick()
    {
        if(enabled)
        {
            PlayerCam = player.GetComponentInChildren<Camera>();

            skippyCam = manager.activeSkippy.GetComponentInChildren<Camera>();

            pointerPosition = inputAction.ReadValue<Vector2>();

            ray = PlayerCam.ScreenPointToRay(pointerPosition);

            lineRenderer.enabled = true;

            if (Physics.Raycast(ray, out hit, 200.0f)) //cursor.position, cursor.forward
            {
                var coordinate = hit.textureCoord;

                float w = coordinate.x * skippyCam.pixelWidth;
                float h = coordinate.y * skippyCam.pixelHeight;

                destination = new Vector2(w, h);
                Ray portalRay = skippyCam.ScreenPointToRay(destination);

                if (Physics.Raycast(portalRay, out hit2, 200.0f)) //Raycast from Skippy's camera to the world space
                {
                    selected = true;
                    draw = true;
                    point = hit2.point;
                    point.y = 0.2f;
                }
            }
        }
        else
        {
            point = Vector3.zero;
            lineRenderer.enabled = false;
        }
    }

    public void DrawTrail()
    {
        if (draw)
        {
            Trail(point);
            if (Vector3.Distance(point, manager.activeSkippy.transform.position) < 0.2)
                draw = false;
        }
        else Trail(hit2.point);
    }

    void Trail(Vector3 end)
    {
        lineRenderer.positionCount = 2;
        start = manager.activeSkippy.transform.position;
        start.y = 0.2f;
        Vector3[] points = { start, end };
        if (end != Vector3.zero) lineRenderer.SetPositions(points);
    }

}
