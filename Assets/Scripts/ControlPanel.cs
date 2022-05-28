using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    GameObject joystick;

    Manager manager;
    PathManager pathManager;
    LineRenderer lineRenderer;

    SinglePath singlePath;
    MultiplePaths multiplePaths;
    JoystickMode joystickMode;
    TankMode tankMode;
    RunButton runButton;

    void Start()
    {
        manager = GetComponentInChildren<Manager>();

        pathManager = GetComponentInChildren<PathManager>();
        lineRenderer = GetComponentInChildren<LineRenderer>();

        singlePath = GetComponentInChildren<SinglePath>();
        multiplePaths = GetComponentInChildren<MultiplePaths>();
        runButton = GetComponentInChildren<RunButton>();

        joystickMode = GetComponentInChildren<JoystickMode>();
        joystick = transform.GetChild(5).gameObject;

        tankMode = GetComponentInChildren<TankMode>();   
    }

    public void SinglePathModeActive()
    {
        DisableMultiplePathsMode();
        DisableJoystickMode();
        DisableTankMode();
    }

    public void MultiplePathModeActive()
    {
        DisableSinglePathMode();
        DisableJoystickMode();
        DisableTankMode();
    }

    public void JoystickModeActive()
    {
        DisablePathMode();
        DisableSinglePathMode();
        DisableMultiplePathsMode();
        DisableTankMode();
    }

    public void TankModeActive()
    {
        DisablePathMode();
        DisableSinglePathMode();
        DisableMultiplePathsMode();
        DisableJoystickMode();
    }

    void DisablePathMode()
    {
        pathManager.draw = false;
        pathManager.enabled = false;
        lineRenderer.enabled = false;
    }

    void DisableSinglePathMode()
    {      
        Button button = singlePath.GetComponentInChildren<Button>();
        ChangeButtonColor(button, false);

        manager.activeSkippy.GetComponent<MoveToPath>().getInput = false;
        manager.activeSkippy.GetComponent<MoveToPath>().excute = false;
        manager.activeSkippy.GetComponent<MoveToPath>().capture = false;
        manager.activeSkippy.GetComponent<MoveToPath>().enabled = false;

        singlePath.end = Vector3.zero;
        singlePath.toggle = false;
    }

    void DisableMultiplePathsMode()
    {
        Button button = multiplePaths.GetComponentInChildren<Button>();
        ChangeButtonColor(button, false);

        manager.activeSkippy.GetComponent<MoveToWaypoints>().waypoints = null;
        manager.activeSkippy.GetComponent<MoveToWaypoints>().go = false;
        manager.activeSkippy.GetComponent<MoveToWaypoints>().enabled = false;

        multiplePaths.waypoints = null;
        multiplePaths.temp.Clear();
        multiplePaths.count = 0;
        multiplePaths.toggle = false;    
    }

    void DisableJoystickMode()
    {
        Button button = joystickMode.GetComponentInChildren<Button>();
        ChangeButtonColor(button, false);
        joystickMode.toggle = false;
        joystick.SetActive(false);
        Origins.Movement.Enable();
        Origins.Rotation.Enable();
    }
    
    void DisableTankMode()
    {
        Button button = tankMode.GetComponentInChildren<Button>();
        ChangeButtonColor(button, false);
        tankMode.toggle = false; 
    }

    public static void ChangeButtonColor(Button button, bool toggle)
    {
        ColorBlock colorBlock = button.colors;
        if(toggle)
        {
            colorBlock.pressedColor = Color.white;
            button.image.color = Color.green;   
        }
        else
        {
            colorBlock.pressedColor = Color.red;
            button.image.color = Color.white;
        }
    }

}
