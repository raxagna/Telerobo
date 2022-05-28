using UnityEngine;
using UnityEngine.UI;

public class InactiveMovingState : ISkippyBaseState
{
    public float timeRemaining;
    bool timerIsRunning = true;

    public override void EnterState(SkippyStateManager skippy, Button moveButton)
    {
        Debug.Log($"You switched from me, {skippy.name.ToString()}, but I still have somewhere to go");
    }

    public override void UpdateState(SkippyStateManager skippy)
    {  
        if (timerIsRunning)
        {
            if (timeRemaining > 0) timeRemaining -= Time.deltaTime;
            else
            {
                skippy.Reach(skippy);
                timerIsRunning = false;
                timeRemaining = 0;
            }
        }
    }

    public override void Instruction(SkippyStateManager skippy, Vector3 clickPos)
    {

    }

    public override void Select(SkippyStateManager skippy)
    {
        skippy.SwitchState(skippy.activeMovingState);
        skippy.GetComponentInChildren<Camera>().enabled = true;
        Debug.Log($"{skippy.name.ToString()} is active!");
    }

    public override void Switch(SkippyStateManager skippy)
    {

    }

    public override void Reach(SkippyStateManager skippy)
    {
        Debug.Log($"This is me, {skippy.name.ToString()}. Just telling you I reached my last assigned target destination");
        skippy.SwitchState(skippy.inactiveIdleState);
    }

}
