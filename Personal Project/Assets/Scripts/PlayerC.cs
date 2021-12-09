using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    [Header("Stats")]
    //Movement
    public float moveSpeed;
    public float jumpForce;
    //Camera
    public float lookSensitivity;
    public float maxlookX;
    public float minlookX;
    private float rotX;
    //components
    private Camera cam;
    private Rigidbody rb;
    public float sprint;
    // Start is called before the first frame update
    void Awake()
    {
    
        // Get the components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Ray ray = new Ray(transform.position, Vector3.down);
        //creates a ray to check if grounded, similar to a drone
        if(Physics.Raycast(ray, 1.1f)){
            moveSpeed = moveSpeed + sprint;
            
             Move();
        }
        }
       else{
           Move();
       }
        CamLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if(moveSpeed > 3.1f)
            {
            moveSpeed = moveSpeed - sprint;
            }
        }
        
    }
    void Move()
    {
    float x = Input.GetAxis("Horizontal") * moveSpeed;
    float z = Input.GetAxis("Vertical") * moveSpeed;
    
    Vector3 dir = transform.right * x + transform.forward * z;
    // Jump direction
    dir.y = rb.velocity.y;
    // apply direction to camera movement
    rb.velocity = dir;

    }
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        //creates a ray to check if grounded, similar to a drone
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
    
    
    rotX = Mathf.Clamp(rotX, minlookX, maxlookX);

    cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
    transform.eulerAngles += Vector3.up * y;
    }
}
