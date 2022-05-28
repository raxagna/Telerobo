using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public List<GameObject> skippyList, inactiveSkippyList;
    public GameObject activeSkippy, previousSkippy;
    GameObject oldSkippy;

    public bool skippySelected, lineupActive, firstChange, changed;

    public UnityEvent OnChanged, OnSelected;

    public List<Button> buttons;

    private void Start()
    {
        if(OnChanged == null) OnChanged = new UnityEvent();
    }


    private void Update()
    {
        inactiveSkippyList = new List<GameObject>(skippyList);
        inactiveSkippyList.Remove(activeSkippy); 

        if (activeSkippy != oldSkippy) SavePreviousSkippy();

        if(changed || firstChange) SwitchSkippy();

        if (activeSkippy != null)
        {
            skippySelected = true;
            OnSelected.Invoke();
        }
            
        if (gameObject.activeSelf) lineupActive = true;      

    }

    void SavePreviousSkippy()
    {
        if (oldSkippy == null)
            firstChange = true;
        else
        {
            OnChanged.Invoke();

            changed = true;
            previousSkippy = oldSkippy;
        }      
        oldSkippy = activeSkippy;   
    }

    void SwitchSkippy()
    {      
        ActivateSkippy(activeSkippy);      
        DeactivateSkippy(inactiveSkippyList);
    }

    void ActivateSkippy(GameObject skippy)
    { 
        PlayerInput input = skippy.GetComponent<PlayerInput>();
        Camera cam = skippy.GetComponentInChildren<Camera>();

        input.ActivateInput();
        cam.enabled = true;
    }

    void DeactivateSkippy(List<GameObject> skippyList)
    {
        foreach (GameObject skippy in skippyList)
        {
            PlayerInput input = skippy.GetComponent<PlayerInput>();
            Camera cam = skippy.GetComponentInChildren<Camera>();

            input.DeactivateInput();
            cam.enabled = false;
        }
    }

}
