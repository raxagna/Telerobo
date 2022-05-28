using UnityEngine;
using UnityEngine.UI;

public class InactiveIdleState : ISkippyBaseState
{

    public override void EnterState(SkippyStateManager skippy, Button moveButton)
    {
        Debug.Log($"{skippy.name.ToString()} is deactivated and idle. Hi!");
    }

    public override void UpdateState(SkippyStateManager skippy)
    {
        
    }

    public override void Instruction(SkippyStateManager skippy, Vector3 clickPos)
    {

    }

    public override void Select(SkippyStateManager skippy)
    {
        skippy.SwitchState(skippy.activeIdleState);
        skippy.GetComponentInChildren<Camera>().enabled = true;
        Debug.Log($"{skippy.name.ToString()} is active!");
    }

    public override void Switch(SkippyStateManager skippy)
    {

    }

    public override void Reach(SkippyStateManager skippy)
    {

    }

}
