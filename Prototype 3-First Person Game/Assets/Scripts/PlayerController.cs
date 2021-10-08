using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
    }
    void Move()
    {
    float x = Input.GetAxis("Horizontal") * moveSpeed;
    float z = Input.GetAxis("Vertical") * moveSpeed;
    
    Vector3 dir = transform.right * x + transform.forward * z;
    // Jump direction
    dir = rb.velocity.y;
    // apply direction to camera movement
    rb.velocity = dir;

    }
    void Jump()
    {
        Ray ray = new Ray(transform.positiion, Vector3.down);
        //creates a ray to check if grounded, similar to a drone
        if(physics.Raycast(ray, 1.1f))
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
