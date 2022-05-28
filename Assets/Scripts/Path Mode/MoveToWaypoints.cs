using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoints : MonoBehaviour
{
    MultiplePaths multiplePaths;
    public Vector3[] waypoints;
    float speed = 3.0f;
    public bool go;
    int i = 0;

    GameObject lineup;
    Manager manager;

    public enum state { stationary, moving }
    public state currentState;

    void Start()
    {
        multiplePaths = GameObject.Find("Control Panel/Multiple Paths/Button").GetComponent<MultiplePaths>();
        lineup = GameObject.Find("Lineup");
        manager = lineup.GetComponent<Manager>();
    }
    private void FixedUpdate()
    {
        if (go) Move();
    }
    public void Move()
    {
        currentState = state.moving;

        float distance = Vector3.Distance(waypoints[i], transform.position);

        if (distance < 0.2)
        {
            i++;
            if (i >= waypoints.Length)
            {
                i = 0;
                go = false;   
            }
        }
        Vector3 relativePos = waypoints[i] - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);

        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[i], speed / 2 * Time.deltaTime);

        if (!go)
        {
            currentState = state.stationary;

            waypoints = null;
            multiplePaths.waypoints = null;

            multiplePaths.temp.Clear();
            multiplePaths.temp.Add(transform.position);
            
            multiplePaths.count = 0;
            enabled = false;
        }
    }
}
