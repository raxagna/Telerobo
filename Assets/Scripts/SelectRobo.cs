using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkippy : MonoBehaviour
{
    Manager manager;
    List<GameObject> skippyList;
    GameObject currentSkippy;

    int index;
    bool toggle;

    Button button;

    private void Start()
    {
        manager = GetComponentInParent<Manager>();
        button = GetComponent<Button>();
    }

    private void Update()
    {       
        skippyList = manager.skippyList;
    }

    public void OnClick()
    {
        index = transform.GetSiblingIndex();
        currentSkippy = skippyList[index];
        manager.activeSkippy = currentSkippy;  
        toggle = !toggle;

        if(toggle) InvokeRepeating("SkippyState", 0.1f, 0.1f);
        else button.image.color = Color.white;
    }

    public void ChangeButtonColors(int state)
    {
        if (state == 1) button.image.color = Color.green;
        else if (state == 2) button.image.color = Color.red;
        else button.image.color = Color.yellow;
    }


    void SkippyState()
    {
        if (currentSkippy.GetComponent<MoveToPath>().currentState == MoveToPath.state.moving || currentSkippy.GetComponent<MoveToWaypoints>().currentState == MoveToWaypoints.state.moving)
            ChangeButtonColors(1); // green
        else
        {
            if(currentSkippy != manager.activeSkippy)
                ChangeButtonColors(2); //red
            else
                ChangeButtonColors(3); //yelow
        }            
    }

}
