using UnityEngine;
using UnityEngine.UI;

public abstract class ISkippyBaseState
{
    public abstract void EnterState(SkippyStateManager skippy, Button moveButton);

    public abstract void UpdateState(SkippyStateManager skippy);

    public abstract void Instruction(SkippyStateManager skippy, Vector3 clickPos);

    public abstract void Select(SkippyStateManager skippy);

    public abstract void Switch(SkippyStateManager skippy);

    public abstract void Reach(SkippyStateManager skippy);
}
