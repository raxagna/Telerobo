using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplePaths : MonoBehaviour
{
    GameObject screen;
    [HideInInspector]
    public List<Vector3> temp;
    public Vector3[] waypoints;
    Vector3 start;

    PathManager pathManager;
    LineRenderer lineRenderer;
    Manager manager;
    Button button;

    public bool toggle;
    ControlPanel controlPanel;

    [HideInInspector] public int waypointsCount, count = 0;
    void Start()
    {
        manager = transform.parent.parent.GetComponentInChildren<Manager>();
        screen = transform.parent.parent.GetComponentInChildren<PathManager>().gameObject;

        lineRenderer = screen.GetComponent<LineRenderer>();

        pathManager = screen.GetComponent<PathManager>();

        temp = new List<Vector3>();

        button = GetComponent<Button>();

        controlPanel = transform.parent.parent.GetComponent<ControlPanel>();

        InvokeRepeating("CreatePath", 0.1f, 0.1f);
    }

    public void OnClick()
    {
        if (manager.lineupActive)
        {
            if (manager.skippySelected)
            {           
                toggle = !toggle;

                pathManager.enabled = toggle;

                ControlPanel.ChangeButtonColor(button, toggle);

                start = manager.activeSkippy.transform.position; start.y = 0.2f;

                if (toggle)
                {
                    temp.Add(start);
                    controlPanel.MultiplePathModeActive();
                }   
            }
            else Debug.Log("Select a Skippy first!");
        }
        else Debug.Log("Spwan a Skippy first!");
    }

    void CreatePath()
    {
        if (toggle)
        {
            if (manager.changed) ChangeSkippy();
            if (pathManager.selected) //if a target destination is selected
            {
                pathManager.selected = false;    
                temp.Add(pathManager.point);
                count += 1;
            }

            if (count < 5)
            {    
                waypoints = temp.ToArray();
                waypointsCount = waypoints.Length;
                lineRenderer.positionCount = waypointsCount;
                lineRenderer.SetPositions(waypoints);
            }
        }
        //else count = 0;
    }

    void ChangeSkippy()
    {
        manager.activeSkippy.GetComponent<MoveToWaypoints>().enabled = true;
        waypoints = null;
        temp.Clear();
        temp.Add(manager.activeSkippy.transform.position);
        count = 0;
        manager.changed = false;
    }

}
