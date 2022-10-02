using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float xMove { get; private set; }
    public bool jumpInput { get; private set; }
   
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        xMove = context.ReadValue<float>();
        Debug.Log(xMove);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInput = true;
            Debug.Log(jumpInput);
        }
    }
    public void OnJump()=> jumpInput = false;
}
