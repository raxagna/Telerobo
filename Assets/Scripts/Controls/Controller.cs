using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public Vector2 inputMovement;
    Vector3 rawInputMovement, rawInputRotation;
    public float moveSpeed;
    readonly float smooth = 7.0f;

    public void OnMove(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        
    }

    public void OnGaze(InputAction.CallbackContext value)
    {
        Vector2 inputRotation = value.ReadValue<Vector2>();
        float yaw = inputRotation.x * smooth;
        rawInputRotation = new Vector3(0, yaw, 0);

    }

    void Update()
    {
        transform.Translate(rawInputMovement * moveSpeed * Time.deltaTime);
        transform.Rotate(rawInputRotation * smooth * Time.deltaTime);

    }

}
