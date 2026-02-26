using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    private InputAction move;
    private InputAction jump;
    private InputAction look;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -30.0f;
    private Vector3 velocity;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float mouseSensY = 5.0f;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera cam;

    [SerializeField] AudioController ac;
    private float camXRotation = 0;


    private void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();

        if (cam == null)
            cam = GetComponentInChildren<Camera>();

        if (ac == null)
            ac = GetComponentInChildren<AudioController>();


        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");
        jump = InputSystem.actions.FindAction("Player/Jump");

        jump.started += Jump;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        jump.started -= Jump;
    }

    void Update()
    {

        Vector2 readMove = move.ReadValue<Vector2>();
        Vector2 readLook = look.ReadValue<Vector2>();

        //Movement of player
        if (controller.isGrounded && velocity.y < 0f)
            velocity.y = -2f; // small downward force to keep grounded

        velocity.y += gravity * Time.deltaTime;

        Vector3 moveWorld = (transform.right * readMove.x + transform.forward * readMove.y) * maxSpeed;

        controller.Move((moveWorld + velocity) * Time.deltaTime);

        //Rotation of player
        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);


        //Rotate the camera
        camXRotation -= mouseSensY * readLook.y * Time.deltaTime;
        camXRotation = Mathf.Clamp(camXRotation, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }

    private void Jump(InputAction.CallbackContext context)
    {

        ac.PlayJumpSFX();
    }

    public void ChangeMouseSensitivity(float value)
    {
        rotationSpeed = value;
        mouseSensY = value;

    }


}
