using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions inputActions;

    private void Awake()
    {
        Instance = this;
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    public Vector2 GetMovementVector()
    {

        return inputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector3 GetMousePositionVector()
    {
        return Mouse.current.position.ReadValue();
    }
}