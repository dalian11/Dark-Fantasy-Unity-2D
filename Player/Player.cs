using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;
    Vector2 inputVector;
    private Rigidbody2D rd;

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;

    private void Awake()
    {
        Instance = this;
        rd = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
    }

    private void FixedUpdate()
    {
        HelbonMolvent();
    }

    private void HelbonMolvent()
    {
        inputVector = inputVector.normalized;
        rd.MovePosition(rd.position + inputVector * movingSpeed * Time.fixedDeltaTime);
        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;   
        }
        else
        {
            isRunning = false;
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerSreenPosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}