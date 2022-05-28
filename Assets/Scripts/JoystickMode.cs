using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoystickMode : MonoBehaviour
{
    GameObject joystick;

    Manager manager;
    ControlPanel controlPanel;
    PlayerInput skippyPlayerInput;

    Button button;

    public bool toggle;
    bool isVr;

    void Start()
    {
        manager = transform.parent.parent.GetComponentInChildren<Manager>();

        button = GetComponent<Button>();

        joystick = transform.parent.parent.GetChild(5).gameObject;

        controlPanel = transform.parent.parent.GetComponent<ControlPanel>();

        if (FindObjectOfType<VRDetector>().isVr) isVr = true;
        else isVr = false;
    }

    private void Update()
    {
        if (manager.skippySelected)
            skippyPlayerInput = manager.activeSkippy.GetComponent<PlayerInput>();
    }

    public void OnClick()
    {
        if (manager.lineupActive)
        {
            if (manager.skippySelected)
            {
                toggle = !toggle;

                skippyPlayerInput.SwitchCurrentActionMap("Joystick");

                if (!isVr) joystick.SetActive(toggle);

                ControlPanel.ChangeButtonColor(button, toggle);

                //controlPanel.JoystickModeActive();

                if (toggle)
                {
                    controlPanel.JoystickModeActive();
                    Origins.Movement.Disable();
                    Origins.Rotation.Disable();
                }
                else
                {
                    Origins.Movement.Enable();
                    Origins.Rotation.Enable();
                }       
            }
            else Debug.Log("Select a Skippy first!");
        }
        else Debug.Log("Spwan a Skippy first!");
    }
    
}
