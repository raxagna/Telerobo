using System.Collections;
using UnityEngine;

public class MoveToPath : MonoBehaviour
{
    PathManager pathManager;
    Rigidbody rb;
    Vector3 target;

    public float speed = 4.0f;
    public bool excute, capture, getInput; //excute & getInput are useful for when switching Skippys since the instance of this script that's attached to the Skippy that has been switched from will be disabled in stage. This is to account for when the user switches Skippys before the previous Skippy is done moving to the last destination it got assigned

    Vector3 relativePos;
    Quaternion toRotation;
    float distance;

    public enum state { stationary, moving }
    public state currentState;

    PathManager placingPoints;

    void Start()
    {
        placingPoints = GameObject.Find("Control Panel/Screen").GetComponent<PathManager>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

    }

    private void Update()
    {
        Calculate();
    }

    private void FixedUpdate()
    {
        if (excute) //Skippy responds to movement only when excute is true, which turns true when you press somewhere to create the first path. It's to prevent Skippy from moving the moment the script is activated until it's given the greenlight to. it's also therefore used when switching between Skippys to disable movement in the previous Skippy *after* it has reached its latest destination.
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target, speed / 2 * Time.deltaTime);

            if (distance > 0.01) currentState = state.moving;
            else currentState = state.stationary;
        }
    }

    void Calculate()
    {
        if (getInput)
            target = placingPoints.point;

        relativePos = target - transform.position;

        if (capture)
        {
            toRotation = Quaternion.LookRotation(relativePos);
            capture = false;
        }

        distance = Vector3.Distance(transform.position, target);
    }

}
