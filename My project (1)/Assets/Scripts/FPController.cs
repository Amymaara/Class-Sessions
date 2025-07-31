using UnityEngine;
using UnityEngine.InputSystem; //need to have it, if using new input system
public class FPController : MonoBehaviour
{
    [Header("Movement Settings")] //aesthetics
    public float moveSpeed = 5f;
    public float gravity = -9.81f; // simulate gravity
    [Header("Look Settings")] //aesthetics
    public Transform cameraTransform;
    public float lookSensitivity = 2f; // mouse/controller sensitivity
    public float verticalLookLimit = 90f; // FOV
    private CharacterController controller; // reference character controller component on player
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity; //move player around scene 
    private float verticalRotation = 0f; // rotate player 
    private void Awake() // awake happens when it is instantiated (faster than start)
    {
        controller = GetComponent<CharacterController>();
        // comment out next 2 lines when developing
        Cursor.lockState = CursorLockMode.Locked; //locks into middle of screen, cursor doesnt move
        Cursor.visible = false; // cursor invisible
    }
    private void Update() // need to run everyframe 
    {
        HandleMovement();
        HandleLook();
    }
    public void OnMovement(InputAction.CallbackContext context) //context = binding
    {
        moveInput = context.ReadValue<Vector2>(); //context value is vector too, returns x,y value
    }
    public void OnLook(InputAction.CallbackContext context) // onLook -> specific make sure correlates to actions
    {
        lookInput = context.ReadValue<Vector2>(); 
    }
    public void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward *
        moveInput.y;
        controller.Move(move * moveSpeed * Time.deltaTime); // controller refers to character controller, move comes from character controller
        if (controller.isGrounded && velocity.y < 0) //isGrounded = grounded, is it touching Y axis. If not touching Y axis then apply gravity
            velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime; // simulates gravity if not touching Y axis, pulls down
        controller.Move(velocity * Time.deltaTime);
    }
    public void HandleLook()
    {
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, // sets a boundary, makes it stick between 2 values. vRotation & vLookLimit
        verticalLookLimit);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); 
        transform.Rotate(Vector3.up * mouseX);
    }
}
