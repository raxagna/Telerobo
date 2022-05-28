using System.Collections.Generic;
using UnityEngine;

public class RunButton : MonoBehaviour
{
    Manager manager;
    MultiplePaths multiplePaths;

    void Start()
    {
        manager = transform.parent.parent.GetComponentInChildren<Manager>();
        multiplePaths = transform.parent.parent.GetComponentInChildren<MultiplePaths>();
    }

    public void OnClick()
    {
        manager.activeSkippy.GetComponent<MoveToWaypoints>().enabled = true;    
        manager.activeSkippy.GetComponent<MoveToWaypoints>().waypoints = multiplePaths.waypoints;
        manager.activeSkippy.GetComponent<MoveToWaypoints>().go = true;    
    }

}
