using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    public float leftSpeed, rightSpeed;

    public void LeafTread(InputAction.CallbackContext value)
    {
        leftSpeed = value.ReadValue<Vector2>().y;
    }
    public void RightTread(InputAction.CallbackContext value)
    {
        rightSpeed = value.ReadValue<Vector2>().y;
    }

}
