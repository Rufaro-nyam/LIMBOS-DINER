using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Title: FPS Controller with Unity's New Input System
    //Author: Practical Programming
    //Date:29 July 2025
    //Availability: https://www.youtube.com/watch?v=tXDgSGOEatk&t=618s

    PlayerInput controls;
    PlayerInput.MovementActions groundmovement;

    [SerializeField] PlayerMovement movement;
    [SerializeField] Hands hands;



    Vector2 mouseInput;
    Vector2 horizontal_input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new PlayerInput();
        groundmovement = controls.Movement;

        groundmovement.Horizontal.performed += ctx => horizontal_input = ctx.ReadValue<Vector2>();
        groundmovement.Jump.performed += _ => movement.onjump_pressed();

        //mouse
        groundmovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundmovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        //hands
        groundmovement.Interact.performed += _ => hands.shoot();
        groundmovement.Drop.performed += _ => hands.drop();

        //QUIT
        groundmovement.QUIT.performed += _ => movement.Quit();

    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        movement.recieveInput(horizontal_input);
        movement.recieveMouseInput(mouseInput);
    }

}
