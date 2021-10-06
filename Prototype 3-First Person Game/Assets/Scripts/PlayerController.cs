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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
    float x = Input.GetAxis("Horizontal") * MoveSpeed;
    float z = Input.GetAxis("Vertical") * MoveSpeed;
    
    rb.velocity = new Vector3(x, rb.velocity.y, z);
    }
}
