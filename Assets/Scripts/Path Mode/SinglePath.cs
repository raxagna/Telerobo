using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SinglePath : MonoBehaviour
{
    GameObject screen;
    public Vector3 end;

    PathManager pathManager;
    Manager manager;
    ControlPanel controlPanel;

    Button button;
    public bool toggle;

    void Start()
    {
        manager = transform.parent.parent.GetComponentInChildren<Manager>();
        screen = transform.parent.parent.GetComponentInChildren<PathManager>().gameObject;

        controlPanel = transform.parent.parent.GetComponent<ControlPanel>();

        pathManager = screen.GetComponent<PathManager>();

        button = GetComponent<Button>();

        manager.OnChanged.AddListener(PsuedoChange);

        InvokeRepeating("Run", 0.1f, 0.1f);
    }

    private void PsuedoChange()
    {
        Debug.Log("psudeo changed");
    }

    public void OnClick()
    {
        if (manager.lineupActive)
        {
            if (manager.skippySelected)
            {
                toggle = !toggle;

                pathManager.enabled = toggle;
                screen.GetComponent<XRSimpleInteractable>().enabled = toggle;

                ControlPanel.ChangeButtonColor(button, toggle);

                manager.activeSkippy.GetComponent<MoveToPath>().enabled = toggle;

                if (toggle) controlPanel.SinglePathModeActive();
            }
            else Debug.Log("Select a Skippy first!");
        }
        else Debug.Log("Spwan a Skippy first!");

    }

    void Run()
    {
        if (toggle)
        {
            if (manager.changed) ChangeSkippy();

            if (pathManager.selected) //if a target destination is selected
            {
                manager.activeSkippy.GetComponent<MoveToPath>().getInput = true;
                manager.activeSkippy.GetComponent<MoveToPath>().capture = true;
                manager.activeSkippy.GetComponent<MoveToPath>().excute = true;
                pathManager.selected = false;
            }

            end = pathManager.point;
            pathManager.DrawTrail();
        }
        else end = Vector3.zero;
    }

    void ChangeSkippy() //do for multiple too
    {

        manager.activeSkippy.GetComponent<MoveToPath>().enabled = true;

        manager.previousSkippy.GetComponent<MoveToPath>().getInput = false;
        manager.previousSkippy.GetComponent<MoveToPath>().capture = false;

        manager.changed = false;
    }

}
