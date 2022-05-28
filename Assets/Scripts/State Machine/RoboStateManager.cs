using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SkippyStateManager : MonoBehaviour
{
    ISkippyBaseState currentState;
    public ActiveIdleState activeIdleState = new ActiveIdleState();
    public ActiveMovingState activeMovingState = new ActiveMovingState();
    public InactiveIdleState inactiveIdleState = new InactiveIdleState();
    public InactiveMovingState inactiveMovingState = new InactiveMovingState();

    public GameObject screen;
    public Button selectButton, moveButton;
    public List<Button> switchButtons;

    public float activeTimer, inactiveTimer;

    void Start()
    {
        currentState = inactiveIdleState;

        currentState.EnterState(this, moveButton);

        screen.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(delegate { Instruction(this); });

        selectButton.onClick.AddListener(delegate { Select(this); });
        moveButton.onClick.AddListener(delegate { Instruction(this); });

        foreach(Button switchButton in switchButtons)
            switchButton.onClick.AddListener(delegate { Switch(this); });
    }

    void Update()
    {
        currentState.UpdateState(this);
        activeTimer = activeMovingState.timeRemaining;
        inactiveTimer = inactiveMovingState.timeRemaining;
    }

    public void Instruction(SkippyStateManager skippy)
    {
        Vector3 clickPos = screen.GetComponent<newPathManager>().clickPosition;
        currentState.Instruction(this, clickPos);
    }

    public void Select(SkippyStateManager skippy)
    {
        currentState.Select(this);
    }

    public void Switch(SkippyStateManager skippy)
    {
        currentState.Switch(this);
        moveButton.onClick.RemoveListener(delegate { Instruction(skippy); });
    }

    public void Reach(SkippyStateManager skippy)
    {
        currentState.Reach(this);
    }

    public void SwitchState(ISkippyBaseState state)
    {
        currentState = state;
        state.EnterState(this, moveButton);
        if (state == inactiveMovingState) inactiveMovingState.timeRemaining = activeMovingState.timeRemaining;
    }

}
