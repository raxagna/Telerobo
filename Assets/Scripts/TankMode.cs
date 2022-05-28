using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TankMode : MonoBehaviour
{
    Manager manager;
    SkidSteering skidSteering;

    PlayerInput skippyPlayerInput;
    ControlPanel controlPanel;

    Button button;

    public bool toggle;

    void Start()
    {
        manager = transform.parent.parent.GetComponentInChildren<Manager>();
        button = GetComponent<Button>();

        skidSteering = GetComponent<SkidSteering>();

        controlPanel = transform.parent.parent.GetComponent<ControlPanel>();    
    }

    private void Update()
    {
        if(manager.skippySelected)
            skippyPlayerInput = manager.activeSkippy.GetComponent<PlayerInput>();  
    }

    public void OnClick()
    {
        if (manager.skippyList != null)
        {
            if (manager.skippySelected)
            {
                toggle = !toggle;

                skidSteering.enabled = toggle;

                skippyPlayerInput.SwitchCurrentActionMap("Tank");
                
                ControlPanel.ChangeButtonColor(button, toggle);

                if (toggle) controlPanel.TankModeActive();             
            }
            else Debug.Log("Select a Skippy first!");
        }
        else Debug.Log("Spwan a Skippy first!");
    }

}
