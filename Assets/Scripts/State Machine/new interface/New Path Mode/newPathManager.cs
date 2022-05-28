using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class newPathManager : MonoBehaviour
{
    public GameObject activeSkippy;
    public InputActionAsset playerInput2D;
    LineRenderer lineRenderer;
    Manager manager;

    VRDetector detector;

    Vector3 coordinate;
    Vector2 destination;
    RaycastHit hitInfo, hit2;
    public Vector3 clickPosition;

    Camera skippyCam;

    Vector3 start;

    public bool selected, changed, draw;

    void Start()
    {
        detector = FindObjectOfType<VRDetector>();
        lineRenderer = GetComponent<LineRenderer>();

        //manager = transform.parent.GetComponentInChildren<Manager>();
        /*
        if (detector.isVr)
        {
            XRRig rig = FindObjectOfType<XRRig>();
            leftHand = rig.transform.Find("Camera Offset/LeftHand Controller");
            rightHand = rig.transform.Find("Camera Offset/RightHand Controller");
            //inputAction = vrInputController.FindActionMap("XRI RightHand").FindAction("Move");
            //player = GameObject.Find("VRPlayer(Clone)");
        }
        else
        {
            inputAction = playerInput2D.FindActionMap("Player").FindAction("Cursor");
            //player = GameObject.Find("2DPlayer(Clone)");
        }
        */
    }

    public void OnClick(SelectEnterEventArgs args)
    {
        if (enabled)
        {
            skippyCam = activeSkippy.GetComponentInChildren<Camera>();

            if (detector.isVr)
            {
                Transform interactor = args.interactor.transform.parent;
                Physics.Raycast(interactor.position, interactor.TransformDirection(Vector3.forward), out hitInfo, 100.0f);
            }
            else
            {
                Physics.Raycast(Camera.main.ScreenPointToRay(playerInput2D.FindAction("Cursor").ReadValue<Vector2>()), out hitInfo, 100.0f);
            }

            coordinate = hitInfo.textureCoord;
            float w = coordinate.x * skippyCam.pixelWidth;
            float h = coordinate.y * skippyCam.pixelHeight;

            destination = new Vector2(w, h);
            Ray portalRay = skippyCam.ScreenPointToRay(destination);

            if (Physics.Raycast(portalRay, out hit2, 200.0f)) //Raycast from Skippy's camera to the world space
            {
                selected = true;
                draw = true;
                clickPosition = hit2.point;
                clickPosition.y = 0.2f;
            }
        }
        else
        {
            clickPosition = Vector3.zero;
            lineRenderer.enabled = false;
        }
    }

    public void DrawTrail()
    {
        if (draw)
        {
            Trail(clickPosition);
            if (Vector3.Distance(clickPosition, activeSkippy.transform.position) < 0.2)
                draw = false;
        }
        else Trail(hit2.point);
    }

    void Trail(Vector3 end)
    {
        lineRenderer.positionCount = 2;
        start = activeSkippy.transform.position;
        start.y = 0.2f;
        Vector3[] points = { start, end };
        if (end != Vector3.zero) lineRenderer.SetPositions(points);
    }

}
