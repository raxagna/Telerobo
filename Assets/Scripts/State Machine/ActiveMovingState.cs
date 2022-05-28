using UnityEngine;
using UnityEngine.UI;

public class ActiveMovingState : ISkippyBaseState
{
    public float timeRemaining = 5;
    bool timerIsRunning;

    public override void EnterState(SkippyStateManager skippy, Button moveButton)
    {
        Debug.Log($"Currently moving {skippy.name.ToString()} to target destination");    
        timerIsRunning = true;
    }

    public override void UpdateState(SkippyStateManager skippy)
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
            else
            {
                skippy.Reach(skippy);
                timeRemaining = 5;
                timerIsRunning = false;
            }
        }      
    }

    public override void Instruction(SkippyStateManager skippy, Vector3 clickPos)
    {
        Debug.Log($"{skippy.name.ToString()}'s destination changed to {clickPos}");
        skippy.transform.SetPositionAndRotation(clickPos, Quaternion.Euler(new Vector3(0, skippy.transform.position.y, 0)));
    }

    public override void Select(SkippyStateManager skippy)
    {
        Debug.Log($"This, {skippy.name.ToString()}, is already selected");
    }

    public override void Switch(SkippyStateManager skippy)
    {
        skippy.SwitchState(skippy.inactiveMovingState);
        skippy.GetComponentInChildren<Camera>().enabled = false;
        timeRemaining = 5;
    }
    public override void Reach(SkippyStateManager skippy)
    {
        Debug.Log($"{skippy.name.ToString()} reached target destination");     
        skippy.SwitchState(skippy.activeIdleState);
    }

}
