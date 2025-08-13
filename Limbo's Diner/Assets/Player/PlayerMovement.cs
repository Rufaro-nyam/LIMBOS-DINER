using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 horizontalinput;

    [SerializeField] float gravity = -30f;
    Vector3 VerticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundlayer;
    bool is_grounded;

    [SerializeField] float jumpheight = 3.5f;
    bool jump;
    bool can_jump;

    //FOR MOUSE
    [SerializeField] float sensetivityx = 8f;
    [SerializeField] float sensetivityy = 0.25f;
    float mousex, mousey;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //is_grounded = Physics.CheckSphere(transform.position, -2.0f, groundlayer);
        can_jump = Physics.CheckSphere(transform.position, 10.0f, groundlayer);

        if (controller.isGrounded)
        {
            VerticalVelocity.y = 0;
        }


        Vector3 Horizontalvelocity = (transform.right * horizontalinput.x + transform.forward * horizontalinput.y) * speed;
        controller.Move(Horizontalvelocity * Time.deltaTime);

        VerticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(VerticalVelocity * Time.deltaTime);

        if (jump && can_jump) 
        {
            

            VerticalVelocity.y = Mathf.Sqrt(-2f * jumpheight * gravity);
            
            
            
        }
        jump = false;

        if (jump) { print("jump pressed"); }
        if (can_jump) {  }

        //MOUSE
        transform.Rotate(Vector3.up, mousex * Time.deltaTime);

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
        
    }


    public void recieveInput(Vector2 _horizontalinput) 
    {
        horizontalinput = _horizontalinput;
        
    }

    public void onjump_pressed() 
    {
        jump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {

    }
    public void recieveMouseInput(Vector2 mouseInput) 
    {
        mousex = mouseInput.x * sensetivityx;
        mousey = mouseInput.y * sensetivityy;
    }
}
