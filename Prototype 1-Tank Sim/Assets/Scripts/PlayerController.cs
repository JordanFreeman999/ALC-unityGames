using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed;
    //left and right input
    public float hInput;
    //forward and back input
    public float vInput;
    // projectile
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Makes the vehicle go left and right
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * hInput);
        //makes the vehicle go forward and back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
        
    }
}
