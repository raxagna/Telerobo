using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class newSinglePath : MonoBehaviour
{
    public GameObject screen, spawner;
    Skippy[] skippys;
    public Vector3 end;

    newPathManager pathManager;
    Manager manager;
    ControlPanel controlPanel;

    Button button;
    public bool toggle;

    void Start()
    {
        //manager = transform.parent.parent.GetComponentInChildren<Manager>();
        //spawner = transform.parent.parent.parent.GetComponentInChildren<newSpawner>().gameObject;
        //screen = transform.parent.parent.GetComponentInChildren<PathManager>().gameObject;
        //controlPanel = transform.parent.parent.GetComponent<ControlPanel>();

        pathManager = screen.GetComponent<newPathManager>();

        button = GetComponent<Button>();
    }

    public void OnClick()
    {
        toggle = !toggle;

        pathManager.enabled = toggle;
        screen.GetComponent<XRSimpleInteractable>().enabled = toggle;

        ControlPanel.ChangeButtonColor(button, toggle);

        //manager.activeSkippy.GetComponent<MoveToPath>().enabled = toggle;

        //if (toggle) controlPanel.SinglePathModeActive();
    }

}
