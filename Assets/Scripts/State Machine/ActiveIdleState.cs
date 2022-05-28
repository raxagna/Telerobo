using UnityEngine;
using UnityEngine.UI;

public class ActiveIdleState : ISkippyBaseState
{

    public override void EnterState(SkippyStateManager skippy, Button moveButton)
    {
        
    }

    public override void UpdateState(SkippyStateManager skippy)
    {
        
    }

    public override void Instruction(SkippyStateManager skippy, Vector3 clickPos)
    {
        skippy.SwitchState(skippy.activeMovingState);
        skippy.transform.SetPositionAndRotation(clickPos, Quaternion.Euler(new Vector3(0, skippy.transform.position.y, 0)));
    }

    public override void Select(SkippyStateManager skippy)
    {
        Debug.Log($"This, {skippy.name.ToString()}, is already selected");
    }

    public override void Switch(SkippyStateManager skippy)
    {
        //Debug.Log($"Switched {skippy.name.ToString()} to inactive");
        skippy.SwitchState(skippy.inactiveIdleState);
        skippy.GetComponentInChildren<Camera>().enabled = false;
    }

    public override void Reach(SkippyStateManager skippy)
    {

    }

}
