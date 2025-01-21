using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSubscription : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public bool JumpInput { get; private set; } = false;
    PlayerInput _Input = null;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _Input = new PlayerInput();
        _Input.Player.Enable();
        _Input.Player.Move.performed += SetMovement;
        _Input.Player.Move.canceled += SetMovement;

    }
    private void OnDisable()
    {
        _Input.Player.Move.performed -= SetMovement;
        _Input.Player.Move.canceled -= SetMovement;
        _Input.Player.Disable();
    }
    private void Update()
    {
        JumpInput = _Input.Player.Jump.WasPressedThisFrame();
    }
    private void SetMovement(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }
    private void SetJump(InputAction.CallbackContext ctx)
    {
        JumpInput = ctx.started;
    }
}
